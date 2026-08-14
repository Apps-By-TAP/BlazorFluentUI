using System.Reflection;
using System.Text.RegularExpressions;
using AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar;
using AppsByTAP.BlazorFluentUI.Components.Chip;
using AppsByTAP.BlazorFluentUI.Components.Forms;
using AppsByTAP.BlazorFluentUI.Components.Theme.Models;
using YamlDotNet.RepresentationModel;

namespace OkfDocsValidator;

public sealed record ValidationResult(bool Success, List<string> Messages, int ComponentCount, int ConceptCount, int ThemeTokenCount);

public static class RepositoryValidator
{
    private static readonly Regex MarkdownLink = new(@"\[[^\]]*\]\((?<target>[^)]+)\)", RegexOptions.Compiled);
    private static readonly Regex RazorFence = new(@"```razor\s*(?<code>[\s\S]*?)```", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex ComponentTag = new(@"<(?<name>[A-Z][A-Za-z0-9]*)\b(?<attributes>[^<>]*?)>", RegexOptions.Compiled);
    private static readonly Regex ComponentAttribute = new(@"(?<bind>@bind-(?<bindName>[A-Za-z_][A-Za-z0-9_]*))\s*=|(?<![@:\w-])(?<name>[A-Z][A-Za-z0-9_]*)\s*=", RegexOptions.Compiled);

    public static ValidationResult Validate(string repositoryRoot)
    {
        List<string> errors = [];
        Inventory inventory = ComponentInventory.Create(repositoryRoot);
        string okfRoot = Path.Combine(repositoryRoot, "docs", "OKF");
        if (!Directory.Exists(okfRoot))
        {
            return new ValidationResult(false, ["docs/OKF does not exist."], inventory.Components.Count, 0, inventory.ThemeTokens.Count);
        }

        string rootIndex = Path.Combine(okfRoot, "index.md");
        if (!File.Exists(rootIndex))
        {
            errors.Add("docs/OKF/index.md is required.");
        }
        else
        {
            ValidateRootIndex(rootIndex, errors);
        }

        Dictionary<string, ConceptDocument> concepts = new(StringComparer.Ordinal);
        foreach (string markdown in Directory.EnumerateFiles(okfRoot, "*.md", SearchOption.AllDirectories))
        {
            string fileName = Path.GetFileName(markdown);
            if (fileName.Equals("index.md", StringComparison.OrdinalIgnoreCase))
            {
                if (!Path.GetFullPath(markdown).Equals(Path.GetFullPath(rootIndex), StringComparison.OrdinalIgnoreCase) && HasFrontmatter(File.ReadAllText(markdown)))
                {
                    errors.Add($"{Relative(repositoryRoot, markdown)}: nested index.md files cannot have frontmatter.");
                }
                ValidateLinks(repositoryRoot, okfRoot, markdown, errors);
                continue;
            }

            if (fileName.Equals("log.md", StringComparison.OrdinalIgnoreCase))
            {
                ValidateLog(repositoryRoot, markdown, errors);
                ValidateLinks(repositoryRoot, okfRoot, markdown, errors);
                continue;
            }

            string text = File.ReadAllText(markdown);
            if (!TryReadFrontmatter(text, out YamlMappingNode? frontmatter, out string? error))
            {
                errors.Add($"{Relative(repositoryRoot, markdown)}: {error}");
                continue;
            }

            string? type = GetScalar(frontmatter!, "type");
            if (string.IsNullOrWhiteSpace(type))
            {
                errors.Add($"{Relative(repositoryRoot, markdown)}: frontmatter requires a non-empty type.");
                continue;
            }

            ConceptDocument concept = new(markdown, text, frontmatter!, type);
            concepts[Path.GetFullPath(markdown)] = concept;
            ValidateLifecycle(repositoryRoot, concept, errors);
            ValidateResourcePaths(repositoryRoot, okfRoot, concept, errors);
            ValidateLinks(repositoryRoot, okfRoot, markdown, errors);
        }

        ValidateComponentCoverage(repositoryRoot, inventory, concepts.Values, errors);
        ValidateSupportingTypes(repositoryRoot, inventory, concepts.Values, errors);
        ValidateThemeTokens(repositoryRoot, inventory, errors);
        ValidateBreakingApi(errors);

        return new ValidationResult(errors.Count == 0, errors, inventory.Components.Count, concepts.Count, inventory.ThemeTokens.Count);
    }

    private static void ValidateRootIndex(string path, List<string> errors)
    {
        string text = File.ReadAllText(path);
        if (!TryReadFrontmatter(text, out YamlMappingNode? frontmatter, out string? error))
        {
            errors.Add($"docs/OKF/index.md: {error}");
            return;
        }

        if (GetScalar(frontmatter!, "okf_version") != "0.2")
        {
            errors.Add("docs/OKF/index.md: okf_version must be \"0.2\".");
        }

        if (frontmatter!.Children.Keys.OfType<YamlScalarNode>().Any(key => key.Value != "okf_version"))
        {
            errors.Add("docs/OKF/index.md: the root index may only declare okf_version in frontmatter.");
        }
    }

    private static void ValidateLog(string repositoryRoot, string path, List<string> errors)
    {
        string text = File.ReadAllText(path);
        if (HasFrontmatter(text))
        {
            errors.Add($"{Relative(repositoryRoot, path)}: log.md cannot have frontmatter.");
        }
        if (!Regex.IsMatch(text, @"(?m)^## \d{4}-\d{2}-\d{2}\s*$"))
        {
            errors.Add($"{Relative(repositoryRoot, path)}: log.md needs an ISO date heading.");
        }
    }

    private static void ValidateLifecycle(string repositoryRoot, ConceptDocument concept, List<string> errors)
    {
        string relative = Relative(repositoryRoot, concept.Path);
        foreach (string field in new[] { "title", "description", "status", "verification_scope" })
        {
            if (string.IsNullOrWhiteSpace(GetScalar(concept.Frontmatter, field)))
            {
                errors.Add($"{relative}: {field} is required by this bundle's metadata policy.");
            }
        }
        if (!concept.Frontmatter.Children.TryGetValue(new YamlScalarNode("tags"), out YamlNode? tagNode) ||
            tagNode is not YamlSequenceNode tags || tags.Children.Count == 0)
        {
            errors.Add($"{relative}: tags must be a non-empty YAML sequence.");
        }
        if (!concept.Frontmatter.Children.TryGetValue(new YamlScalarNode("sources"), out YamlNode? sourceNode) ||
            sourceNode is not YamlSequenceNode sources || sources.Children.Count == 0)
        {
            errors.Add($"{relative}: sources must be a non-empty YAML sequence.");
        }
        else
        {
            foreach (YamlMappingNode source in sources.Children.OfType<YamlMappingNode>())
            {
                if (string.IsNullOrWhiteSpace(GetScalar(source, "resource"))) errors.Add($"{relative}: every sources entry requires resource.");
            }
        }

        string? status = GetScalar(concept.Frontmatter, "status");
        if (status is not null && status is not ("draft" or "stable" or "deprecated"))
        {
            errors.Add($"{relative}: status must be draft, stable, or deprecated.");
        }
        string? generatedBy = GetNestedScalar(concept.Frontmatter, "generated", "by");
        if (string.IsNullOrWhiteSpace(generatedBy))
        {
            errors.Add($"{relative}: generated.by is required by this bundle's trust policy.");
        }
        if (string.IsNullOrWhiteSpace(GetNestedScalar(concept.Frontmatter, "generated", "at")))
        {
            errors.Add($"{relative}: generated.at is required by this bundle's trust policy.");
        }
        if (!concept.Frontmatter.Children.TryGetValue(new YamlScalarNode("verified"), out YamlNode? verifiedNode) ||
            !VerificationEventsAreComplete(verifiedNode))
        {
            errors.Add($"{relative}: verified must contain at least one event with by and at.");
        }
    }

    private static bool VerificationEventsAreComplete(YamlNode node)
    {
        IEnumerable<YamlMappingNode> events = node switch
        {
            YamlMappingNode mapping => [mapping],
            YamlSequenceNode sequence => sequence.Children.OfType<YamlMappingNode>(),
            _ => []
        };
        List<YamlMappingNode> materialized = events.ToList();
        return materialized.Count > 0 && materialized.All(item =>
            !string.IsNullOrWhiteSpace(GetScalar(item, "by")) && !string.IsNullOrWhiteSpace(GetScalar(item, "at")));
    }

    private static void ValidateComponentCoverage(string repositoryRoot, Inventory inventory, IEnumerable<ConceptDocument> concepts, List<string> errors)
    {
        Dictionary<string, ConceptDocument> componentDocs = concepts
            .Where(concept => concept.Type == "Blazor Component")
            .Where(concept => !string.IsNullOrWhiteSpace(GetScalar(concept.Frontmatter, "dotnet_type")))
            .GroupBy(concept => GetScalar(concept.Frontmatter, "dotnet_type")!, StringComparer.Ordinal)
            .ToDictionary(group => group.Key, group => group.First(), StringComparer.Ordinal);

        foreach (IGrouping<string, ConceptDocument> duplicate in concepts
                     .Where(concept => concept.Type == "Blazor Component")
                     .GroupBy(concept => GetScalar(concept.Frontmatter, "dotnet_type") ?? "", StringComparer.Ordinal)
                     .Where(group => string.IsNullOrWhiteSpace(group.Key) || group.Count() != 1))
        {
            errors.Add(string.IsNullOrWhiteSpace(duplicate.Key)
                ? "A Blazor Component concept is missing dotnet_type."
                : $"Component type '{duplicate.Key}' has {duplicate.Count()} documentation pages; expected one.");
        }

        Dictionary<string, ComponentContract> contracts = inventory.Components.ToDictionary(component => component.FullName, StringComparer.Ordinal);
        HashSet<string> missingPages = FindMissingComponentPages(contracts.Keys, componentDocs.Keys).ToHashSet(StringComparer.Ordinal);
        foreach (ComponentContract component in inventory.Components)
        {
            if (missingPages.Contains(component.FullName) || !componentDocs.TryGetValue(component.FullName, out ConceptDocument? document))
            {
                errors.Add($"Missing component page for {component.FullName} ({component.Source}).");
                continue;
            }

            string? documentedSource = GetScalar(document.Frontmatter, "component_source");
            if (!string.Equals(documentedSource, component.Source, StringComparison.Ordinal))
            {
                errors.Add($"{Relative(repositoryRoot, document.Path)}: component_source must be '{component.Source}'.");
            }

            ValidateParameterTable(repositoryRoot, document, component.Parameters, "parameters", errors);
            ValidateParameterTable(repositoryRoot, document, component.CascadingParameters, "cascading-parameters", errors);
            ValidateGenericParameters(repositoryRoot, document, component, errors);
        }

        foreach (string extra in componentDocs.Keys.Except(contracts.Keys, StringComparer.Ordinal))
        {
            errors.Add($"Component page references unknown compiled type '{extra}'.");
        }

        ValidateExamples(repositoryRoot, concepts, inventory.Components, errors);
    }

    internal static List<string> FindMissingComponentPages(IEnumerable<string> expected, IEnumerable<string> documented)
        => expected.Except(documented, StringComparer.Ordinal).OrderBy(name => name, StringComparer.Ordinal).ToList();

    private static void ValidateParameterTable(string repositoryRoot, ConceptDocument document, List<ParameterContract> expected, string marker, List<string> errors)
    {
        List<TableRow> rows = ParseApiTable(document.Text, marker);
        Dictionary<string, TableRow> actual = rows.GroupBy(row => row.Name, StringComparer.Ordinal).ToDictionary(group => group.Key, group => group.First(), StringComparer.Ordinal);
        foreach (ParameterContract parameter in expected)
        {
            if (!actual.TryGetValue(parameter.Name, out TableRow? row))
            {
                errors.Add($"{Relative(repositoryRoot, document.Path)}: {marker} table is missing '{parameter.Name}'.");
                continue;
            }
            if (!string.Equals(row.Type, parameter.Type, StringComparison.Ordinal))
            {
                errors.Add($"{Relative(repositoryRoot, document.Path)}: '{parameter.Name}' type is '{row.Type}', expected '{parameter.Type}'.");
            }
            if (!string.Equals(row.Binding, parameter.Binding, StringComparison.Ordinal))
            {
                errors.Add($"{Relative(repositoryRoot, document.Path)}: '{parameter.Name}' binding is '{row.Binding}', expected '{parameter.Binding}'.");
            }
            if (!string.Equals(row.Default, parameter.Default, StringComparison.Ordinal))
            {
                errors.Add($"{Relative(repositoryRoot, document.Path)}: '{parameter.Name}' default is '{row.Default}', expected '{parameter.Default}'.");
            }
            if (!string.Equals(row.Required, parameter.Required, StringComparison.Ordinal))
            {
                errors.Add($"{Relative(repositoryRoot, document.Path)}: '{parameter.Name}' requiredness is '{row.Required}', expected '{parameter.Required}'.");
            }
            if (!string.Equals(row.DeclaredBy, parameter.DeclaredBy, StringComparison.Ordinal))
            {
                errors.Add($"{Relative(repositoryRoot, document.Path)}: '{parameter.Name}' declaring type is '{row.DeclaredBy}', expected '{parameter.DeclaredBy}'.");
            }
        }

        foreach (string extra in FindUnknownDocumentedParameters(document.Text, expected, marker))
        {
            errors.Add($"{Relative(repositoryRoot, document.Path)}: {marker} table documents unknown parameter '{extra}'.");
        }
    }

    internal static List<string> FindUnknownDocumentedParameters(string text, IEnumerable<ParameterContract> expected, string marker)
        => ParseApiTable(text, marker).Select(row => row.Name)
            .Except(expected.Select(parameter => parameter.Name), StringComparer.Ordinal)
            .OrderBy(name => name, StringComparer.Ordinal)
            .ToList();

    private static void ValidateGenericParameters(string repositoryRoot, ConceptDocument document, ComponentContract component, List<string> errors)
    {
        List<string> documented = GetSequence(document.Frontmatter, "generic_parameters");
        if (!documented.SequenceEqual(component.GenericParameters, StringComparer.Ordinal))
        {
            errors.Add($"{Relative(repositoryRoot, document.Path)}: generic_parameters must be [{string.Join(", ", component.GenericParameters)}].");
        }
    }

    private static void ValidateExamples(string repositoryRoot, IEnumerable<ConceptDocument> concepts, List<ComponentContract> components, List<string> errors)
    {
        Dictionary<string, List<ComponentContract>> byName = components.GroupBy(component => component.Name, StringComparer.Ordinal)
            .ToDictionary(group => group.Key, group => group.ToList(), StringComparer.Ordinal);
        foreach (ConceptDocument document in concepts.Where(concept => concept.Type == "Blazor Component"))
        {
            string? pageType = GetScalar(document.Frontmatter, "dotnet_type");
            foreach (Match fence in RazorFence.Matches(document.Text))
            {
                foreach (string error in ValidateExampleSnippet(fence.Groups["code"].Value, pageType, byName))
                {
                    errors.Add($"{Relative(repositoryRoot, document.Path)}: {error}");
                }
            }
        }
    }

    internal static List<string> ValidateExampleSnippet(string snippet, string? pageType, Dictionary<string, List<ComponentContract>> byName)
    {
        List<string> errors = [];
        foreach (Match tag in ComponentTag.Matches(snippet))
        {
            string name = tag.Groups["name"].Value;
            if (!byName.TryGetValue(name, out List<ComponentContract>? candidates)) continue;
            ComponentContract component = candidates.FirstOrDefault(candidate => candidate.FullName == pageType) ?? candidates[0];
            HashSet<string> parameters = component.Parameters.Select(parameter => parameter.Name).ToHashSet(StringComparer.Ordinal);
            HashSet<string> genericParameters = component.GenericParameters.ToHashSet(StringComparer.Ordinal);
            foreach (Match attribute in ComponentAttribute.Matches(tag.Groups["attributes"].Value))
            {
                if (attribute.Groups["bind"].Success)
                {
                    string bindName = attribute.Groups["bindName"].Value;
                    if (!parameters.Contains(bindName) || !parameters.Contains(bindName + "Changed"))
                    {
                        errors.Add($"<{name}> uses invalid binding '@bind-{bindName}'.");
                    }
                    continue;
                }

                string attributeName = attribute.Groups["name"].Value;
                if (attributeName is "Context" or "Key" || genericParameters.Contains(attributeName)) continue;
                if (!parameters.Contains(attributeName))
                {
                    errors.Add($"<{name}> uses unknown parameter '{attributeName}'.");
                }
            }
        }
        return errors;
    }

    private static void ValidateSupportingTypes(string repositoryRoot, Inventory inventory, IEnumerable<ConceptDocument> concepts, List<string> errors)
    {
        ConceptDocument? reference = concepts.SingleOrDefault(concept => GetScalar(concept.Frontmatter, "reference_id") == "public-types");
        if (reference is null)
        {
            errors.Add("Missing public supporting types reference (reference_id: public-types).");
            return;
        }

        foreach (SupportingTypeContract type in inventory.SupportingTypes)
        {
            if (!reference.Text.Contains($"`{type.FullName}`", StringComparison.Ordinal))
            {
                errors.Add($"{Relative(repositoryRoot, reference.Path)}: missing public type '{type.FullName}'.");
            }
            foreach (string member in type.Members)
            {
                if (!reference.Text.Contains($"`{member}`", StringComparison.Ordinal))
                {
                    errors.Add($"{Relative(repositoryRoot, reference.Path)}: missing member '{type.FullName}.{member}'.");
                }
            }
        }
    }

    private static void ValidateThemeTokens(string repositoryRoot, Inventory inventory, List<string> errors)
    {
        HashSet<string> valid = inventory.ThemeTokens.ToHashSet(StringComparer.Ordinal);
        string componentRoot = Path.Combine(repositoryRoot, ComponentInventory.ComponentProjectRelative.Replace('/', Path.DirectorySeparatorChar));
        IEnumerable<string> files = Directory.EnumerateFiles(componentRoot, "*", SearchOption.AllDirectories)
            .Where(path => !path.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}") && !path.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}"))
            .Where(path => new[] { ".razor", ".css", ".cs" }.Contains(Path.GetExtension(path), StringComparer.OrdinalIgnoreCase))
            .Concat(Directory.EnumerateFiles(Path.Combine(repositoryRoot, "docs", "OKF"), "*.md", SearchOption.AllDirectories));
        foreach (string file in files)
        {
            foreach (string unknown in FindUnknownTokens(File.ReadAllText(file), valid))
            {
                errors.Add($"{Relative(repositoryRoot, file)}: unknown theme token '{unknown}'.");
            }
        }

        Assembly assembly = typeof(ThemeProvider).Assembly;
        foreach (string typeName in new[]
                 {
                     "AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light.LightThemePalette",
                     "AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark.DarkThemePalette"
                 })
        {
            Type type = assembly.GetType(typeName)!;
            object palette = Activator.CreateInstance(type)!;
            foreach (PropertyInfo property in type.GetProperties())
            {
                string value = property.GetValue(palette)?.ToString() ?? "";
                if (value.StartsWith('#') && !Regex.IsMatch(value, @"^#(?:[0-9a-fA-F]{3}|[0-9a-fA-F]{4}|[0-9a-fA-F]{6}|[0-9a-fA-F]{8})$"))
                {
                    errors.Add($"{type.Name}.{property.Name} has malformed CSS color '{value}'.");
                }
            }
        }

        string themePage = Path.Combine(repositoryRoot, "docs", "OKF", "components", "theme.md");
        if (!File.Exists(themePage))
        {
            errors.Add("docs/OKF/components/theme.md is required for the emitted token reference.");
            return;
        }
        Dictionary<string, (string Light, string Dark)> documentedTokens = Regex.Matches(
                File.ReadAllText(themePage),
                @"(?m)^\|\s*`(?<name>--[A-Za-z0-9_-]+)`\s*\|\s*`(?<light>[^`]*)`\s*\|\s*`(?<dark>[^`]*)`\s*\|\s*$")
            .GroupBy(match => match.Groups["name"].Value, StringComparer.Ordinal)
            .ToDictionary(
                group => group.Key,
                group => (group.First().Groups["light"].Value, group.First().Groups["dark"].Value),
                StringComparer.Ordinal);
        foreach (ThemeTokenContract token in inventory.ThemeTokenValues)
        {
            if (!documentedTokens.TryGetValue(token.Name, out (string Light, string Dark) values))
            {
                errors.Add($"docs/OKF/components/theme.md: missing emitted token row '{token.Name}'.");
                continue;
            }
            if (values.Light != token.LightValue || values.Dark != token.DarkValue)
            {
                errors.Add($"docs/OKF/components/theme.md: '{token.Name}' values are stale; expected light '{token.LightValue}' and dark '{token.DarkValue}'.");
            }
        }
        if (documentedTokens.Count != inventory.ThemeTokenValues.Count)
        {
            errors.Add($"docs/OKF/components/theme.md: expected exactly {inventory.ThemeTokenValues.Count} emitted token rows, found {documentedTokens.Count}.");
        }
    }

    internal static List<string> FindUnknownTokens(string text, HashSet<string> valid)
        => Regex.Matches(text, @"var\((?<token>--[A-Za-z0-9_-]+)")
            .Select(match => match.Groups["token"].Value)
            .Where(token => !valid.Contains(token))
            .Distinct(StringComparer.Ordinal)
            .OrderBy(token => token, StringComparer.Ordinal)
            .ToList();

    private static void ValidateBreakingApi(List<string> errors)
    {
        Type navigation = typeof(NavigationItem);
        if (navigation.GetProperty("Icon") is null || navigation.GetProperty("ICon") is not null)
            errors.Add("Breaking API assertion failed for NavigationItem.Icon/ICon.");
        if (!Enum.GetNames<ChipType>().Contains("Choice") || Enum.GetNames<ChipType>().Contains("Choise"))
            errors.Add("Breaking API assertion failed for ChipType.Choice/Choise.");
        if (typeof(ValidationResult<>).Name != "ValidationResult`1")
            errors.Add("Breaking API assertion failed for ValidationResult<T>.");
        Type formsTextField = typeof(ValidationResult<>).Assembly.GetType("AppsByTAP.BlazorFluentUI.Components.Forms.TextField")!;
        if (formsTextField.GetProperty("CustomValidation") is null || formsTextField.GetProperty("CustomValendation") is not null)
            errors.Add("Breaking API assertion failed for Forms.TextField.CustomValidation/CustomValendation.");
    }

    private static void ValidateLinks(string repositoryRoot, string okfRoot, string markdown, List<string> errors)
    {
        string text = File.ReadAllText(markdown);
        foreach (Match match in MarkdownLink.Matches(text))
        {
            string target = match.Groups["target"].Value.Trim().Trim('<', '>');
            if (!LocalLinkExists(markdown, target, okfRoot))
            {
                errors.Add($"{Relative(repositoryRoot, markdown)}: broken local link '{target}'.");
            }
        }
    }

    internal static bool LocalLinkExists(string markdown, string target, string okfRoot)
    {
        if (target.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
            target.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ||
            target.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase) ||
            target.StartsWith('#')) return true;
        string withoutAnchor = target.Split('#')[0].Replace('/', Path.DirectorySeparatorChar);
        if (string.IsNullOrWhiteSpace(withoutAnchor)) return true;
        string resolved = target.StartsWith('/')
            ? Path.Combine(okfRoot, withoutAnchor.TrimStart(Path.DirectorySeparatorChar))
            : Path.GetFullPath(Path.Combine(Path.GetDirectoryName(markdown)!, withoutAnchor));
        return File.Exists(resolved) || Directory.Exists(resolved);
    }

    private static void ValidateResourcePaths(string repositoryRoot, string okfRoot, ConceptDocument concept, List<string> errors)
    {
        List<string> resources = [];
        if (GetScalar(concept.Frontmatter, "resource") is string resource) resources.Add(resource);
        if (concept.Frontmatter.Children.TryGetValue(new YamlScalarNode("sources"), out YamlNode? sourceNode) && sourceNode is YamlSequenceNode sources)
        {
            resources.AddRange(sources.Children.OfType<YamlMappingNode>()
                .Select(source => GetScalar(source, "resource"))
                .Where(value => !string.IsNullOrWhiteSpace(value))!);
        }

        foreach (string value in resources)
        {
            if (value.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                value.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ||
                value.StartsWith("urn:", StringComparison.OrdinalIgnoreCase)) continue;
            string path = value.Replace('/', Path.DirectorySeparatorChar);
            string resolved = value.StartsWith('/')
                ? Path.Combine(okfRoot, path.TrimStart(Path.DirectorySeparatorChar))
                : Path.GetFullPath(Path.Combine(Path.GetDirectoryName(concept.Path)!, path));
            if (!File.Exists(resolved) && !Directory.Exists(resolved))
            {
                errors.Add($"{Relative(repositoryRoot, concept.Path)}: unresolved resource path '{value}'.");
            }
        }
    }

    internal static bool TryReadFrontmatter(string text, out YamlMappingNode? mapping, out string? error)
    {
        mapping = null;
        error = null;
        if (!HasFrontmatter(text))
        {
            error = "missing YAML frontmatter.";
            return false;
        }

        int end = text.IndexOf("\n---", 4, StringComparison.Ordinal);
        if (end < 0)
        {
            error = "frontmatter closing delimiter is missing.";
            return false;
        }

        string yaml = text[4..end];
        try
        {
            YamlStream stream = [];
            stream.Load(new StringReader(yaml));
            mapping = stream.Documents.Single().RootNode as YamlMappingNode;
            if (mapping is null)
            {
                error = "frontmatter must be a YAML mapping.";
                return false;
            }
            return true;
        }
        catch (Exception exception)
        {
            error = "invalid YAML frontmatter: " + exception.Message;
            return false;
        }
    }

    private static bool HasFrontmatter(string text) => text.StartsWith("---\n", StringComparison.Ordinal) || text.StartsWith("---\r\n", StringComparison.Ordinal);

    private static string? GetScalar(YamlMappingNode mapping, string key)
        => mapping.Children.TryGetValue(new YamlScalarNode(key), out YamlNode? value) ? (value as YamlScalarNode)?.Value : null;

    private static string? GetNestedScalar(YamlMappingNode mapping, string key, string nested)
        => mapping.Children.TryGetValue(new YamlScalarNode(key), out YamlNode? value) && value is YamlMappingNode child
            ? GetScalar(child, nested)
            : null;

    private static List<string> GetSequence(YamlMappingNode mapping, string key)
        => mapping.Children.TryGetValue(new YamlScalarNode(key), out YamlNode? value) && value is YamlSequenceNode sequence
            ? sequence.Children.OfType<YamlScalarNode>().Select(node => node.Value ?? "").ToList()
            : [];

    private static List<TableRow> ParseApiTable(string text, string marker)
    {
        string startMarker = $"<!-- {marker}:start -->";
        string endMarker = $"<!-- {marker}:end -->";
        int start = text.IndexOf(startMarker, StringComparison.Ordinal);
        int end = text.IndexOf(endMarker, StringComparison.Ordinal);
        if (start < 0 || end <= start) return [];
        return text[(start + startMarker.Length)..end]
            .Split('\n')
            .Select(line => line.Trim())
            .Where(line => line.StartsWith('|') && !line.Contains("---", StringComparison.Ordinal) && !line.Contains("| Name |", StringComparison.Ordinal))
            .Select(line => line.Trim('|').Split('|').Select(column => column.Trim().Trim('`')).ToArray())
            .Where(columns => columns.Length >= 7)
            .Select(columns => new TableRow(columns[0], columns[1], columns[2], columns[3], columns[4], columns[5]))
            .ToList();
    }

    private static string Relative(string root, string path) => ComponentInventory.ToPosix(Path.GetRelativePath(root, path));

    private sealed record ConceptDocument(string Path, string Text, YamlMappingNode Frontmatter, string Type);
    private sealed record TableRow(string Name, string Type, string Default, string Required, string Binding, string DeclaredBy);
}
