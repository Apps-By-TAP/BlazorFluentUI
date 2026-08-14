using System.Reflection;
using System.Text.RegularExpressions;
using AppsByTAP.BlazorFluentUI.Components.Theme.Models;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;
using Microsoft.AspNetCore.Components;

namespace OkfDocsValidator;

public sealed record Inventory(string ComponentRoot, List<ComponentContract> Components, List<SupportingTypeContract> SupportingTypes, List<ThemeTokenContract> ThemeTokenValues)
{
    public List<string> ThemeTokens => ThemeTokenValues.Select(token => token.Name).ToList();
}

public sealed record ComponentContract(
    string Name,
    string FullName,
    string DisplayType,
    string Source,
    string Namespace,
    List<string> GenericParameters,
    string BaseType,
    List<ParameterContract> Parameters,
    List<ParameterContract> CascadingParameters,
    List<string> SourceFiles,
    List<string> InjectedServices,
    List<string> JavaScriptModules,
    List<string> ThemeTokens);

public sealed record ParameterContract(string Name, string Type, string Default, string Required, string Binding, string DeclaredBy);
public sealed record SupportingTypeContract(string FullName, string Kind, List<string> Members);
public sealed record ThemeTokenContract(string Name, string LightValue, string DarkValue);

public static class ComponentInventory
{
    public const string ComponentProjectRelative = "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components";
    private const string RootNamespace = "AppsByTAP.BlazorFluentUI.Components";

    public static Inventory Create(string repositoryRoot)
    {
        string componentRoot = Path.Combine(repositoryRoot, ComponentProjectRelative.Replace('/', Path.DirectorySeparatorChar));
        Assembly assembly = typeof(ThemeProvider).Assembly;
        List<ComponentContract> components = [];

        foreach (string razorPath in Directory.EnumerateFiles(componentRoot, "*.razor", SearchOption.AllDirectories)
                     .Where(path => !IsBuildPath(path) && !path.EndsWith("_Imports.razor", StringComparison.OrdinalIgnoreCase))
                     .OrderBy(path => path, StringComparer.OrdinalIgnoreCase))
        {
            components.Add(CreateComponent(repositoryRoot, componentRoot, razorPath, assembly));
        }

        HashSet<Type> componentTypes = components
            .Select(component => ResolveType(assembly, component.FullName))
            .ToHashSet();

        List<SupportingTypeContract> supportingTypes = assembly.GetTypes()
            .Where(type => type.IsPublic && type.Namespace?.StartsWith(RootNamespace, StringComparison.Ordinal) == true)
            .Where(type => !componentTypes.Contains(type))
            .OrderBy(type => type.FullName, StringComparer.Ordinal)
            .Select(CreateSupportingType)
            .ToList();

        List<ThemeTokenContract> themeTokens = GetThemeTokenValues();
        return new Inventory(ToPosix(Path.GetRelativePath(repositoryRoot, componentRoot)), components, supportingTypes, themeTokens);
    }

    public static Type ResolveType(Assembly assembly, string fullName)
        => assembly.GetType(fullName) ?? throw new InvalidOperationException($"Compiled component type '{fullName}' was not found.");

    private static ComponentContract CreateComponent(string repositoryRoot, string componentRoot, string razorPath, Assembly assembly)
    {
        string relative = ToPosix(Path.GetRelativePath(componentRoot, razorPath));
        string text = File.ReadAllText(razorPath);
        string name = Path.GetFileNameWithoutExtension(razorPath);
        string directoryNamespace = Path.GetDirectoryName(relative)?.Replace('/', '.').Replace('\\', '.') ?? "";
        string explicitNamespace = Regex.Match(text, @"(?m)^@namespace\s+(?<namespace>\S+)").Groups["namespace"].Value;
        string componentNamespace = string.IsNullOrWhiteSpace(explicitNamespace)
            ? string.Join('.', new[] { RootNamespace, directoryNamespace }.Where(value => !string.IsNullOrWhiteSpace(value)))
            : explicitNamespace;
        List<string> genericParameters = Regex.Matches(text, @"(?m)^@typeparam\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)")
            .Select(match => match.Groups["name"].Value)
            .ToList();
        string reflectionName = componentNamespace + "." + name + (genericParameters.Count == 0 ? "" : $"`{genericParameters.Count}");
        Type componentType = ResolveType(assembly, reflectionName);
        Type inspectType = CloseGeneric(componentType);
        object? instance = TryCreateInstance(inspectType);

        List<ParameterContract> parameters = [];
        List<ParameterContract> cascading = [];
        const BindingFlags propertyFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        foreach (PropertyInfo property in componentType.GetProperties(propertyFlags))
        {
            bool isParameter = property.GetCustomAttribute<ParameterAttribute>(true) is not null;
            bool isCascading = property.GetCustomAttribute<CascadingParameterAttribute>(true) is not null;
            if (!isParameter && !isCascading)
            {
                continue;
            }

            PropertyInfo defaultProperty = inspectType.GetProperty(property.Name, propertyFlags) ?? property;
            ParameterContract contract = new(
                property.Name,
                FormatType(property.PropertyType),
                FormatDefault(instance, defaultProperty),
                property.GetCustomAttribute<EditorRequiredAttribute>(true) is null ? "No" : "Yes",
                BindingFor(componentType, property),
                FriendlyTypeName(property.DeclaringType));

            (isCascading ? cascading : parameters).Add(contract);
        }

        List<string> sourceFiles = Directory.EnumerateFiles(Path.GetDirectoryName(razorPath)!, name + ".*")
            .Where(path => !IsBuildPath(path))
            .Select(path => ToPosix(Path.GetRelativePath(repositoryRoot, path)))
            .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
            .ToList();
        string combinedSource = string.Join('\n', sourceFiles.Select(path => File.ReadAllText(Path.Combine(repositoryRoot, path.Replace('/', Path.DirectorySeparatorChar)))));
        List<string> injections = Regex.Matches(combinedSource, @"\[Inject\]\s*(?:public\s+)?(?<type>[A-Za-z0-9_<>.,?]+)\s+[A-Za-z_][A-Za-z0-9_]*")
            .Select(match => match.Groups["type"].Value)
            .Distinct(StringComparer.Ordinal)
            .OrderBy(value => value, StringComparer.Ordinal)
            .ToList();
        List<string> jsModules = Regex.Matches(combinedSource, "[\\\"'](?<module>\\.?/?_content/[^\\\"']+\\.js)[\\\"']")
            .Select(match => match.Groups["module"].Value)
            .Distinct(StringComparer.Ordinal)
            .OrderBy(value => value, StringComparer.Ordinal)
            .ToList();
        List<string> tokens = Regex.Matches(combinedSource, @"var\((?<token>--[A-Za-z0-9_-]+)")
            .Select(match => match.Groups["token"].Value)
            .Distinct(StringComparer.Ordinal)
            .OrderBy(value => value, StringComparer.Ordinal)
            .ToList();

        return new ComponentContract(
            name,
            reflectionName,
            FriendlyTypeName(componentType),
            ToPosix(Path.GetRelativePath(repositoryRoot, razorPath)),
            componentNamespace,
            genericParameters,
            FriendlyTypeName(componentType.BaseType),
            parameters.OrderBy(parameter => parameter.Name, StringComparer.Ordinal).ToList(),
            cascading.OrderBy(parameter => parameter.Name, StringComparer.Ordinal).ToList(),
            sourceFiles,
            injections,
            jsModules,
            tokens);
    }

    private static SupportingTypeContract CreateSupportingType(Type type)
    {
        string kind = type.IsEnum ? "enum" : type.IsInterface ? "interface" : type.IsValueType ? "struct" : "class";
        List<string> members;
        if (type.IsEnum)
        {
            members = Enum.GetNames(type).ToList();
        }
        else
        {
            members = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Select(property => $"{property.Name}: {FormatType(property.PropertyType)}")
                .Concat(type.GetEvents(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                    .Select(@event => $"{@event.Name}: {FormatType(@event.EventHandlerType!)}"))
                .OrderBy(value => value, StringComparer.Ordinal)
                .ToList();
        }

        return new SupportingTypeContract(type.FullName ?? type.Name, kind, members);
    }

    private static List<ThemeTokenContract> GetThemeTokenValues()
    {
        var light = new ThemeProvider(new LightThemePalette()).Theme;
        var dark = new ThemeProvider(new DarkThemePalette()).Theme;
        List<ThemeTokenContract> values = [];
        AddTokenValues(values, "--palette-", light.Palette, dark.Palette);
        AddTokenValues(values, "--semanticColors-", light.SemanticColors, dark.SemanticColors);
        AddTokenValues(values, "--semanticTextColors-", light.SemanticTextColors, dark.SemanticTextColors);
        values.Add(new ThemeTokenContract("--label-font-weight", "600", "600"));
        values.Add(new ThemeTokenContract("--label-padding-bottom", "5px", "5px"));
        return values.OrderBy(value => value.Name, StringComparer.Ordinal).ToList();
    }

    private static void AddTokenValues(List<ThemeTokenContract> values, string prefix, object light, object dark)
    {
        Dictionary<string, string> darkValues = dark.GetType().GetProperties()
            .ToDictionary(property => property.Name, property => property.GetValue(dark)?.ToString() ?? "", StringComparer.Ordinal);
        foreach (PropertyInfo property in light.GetType().GetProperties())
        {
            values.Add(new ThemeTokenContract(
                prefix + property.Name,
                property.GetValue(light)?.ToString() ?? "",
                darkValues[property.Name]));
        }
    }

    private static string BindingFor(Type componentType, PropertyInfo property)
    {
        if (property.Name.EndsWith("Changed", StringComparison.Ordinal))
        {
            return "-";
        }

        PropertyInfo? changed = componentType.GetProperty(property.Name + "Changed", BindingFlags.Instance | BindingFlags.Public);
        return changed?.GetCustomAttribute<ParameterAttribute>(true) is null ? "-" : $"@bind-{property.Name}";
    }

    private static object? TryCreateInstance(Type type)
    {
        try { return Activator.CreateInstance(type); }
        catch { return null; }
    }

    private static string FormatDefault(object? instance, PropertyInfo property)
    {
        if (instance is null || !property.CanRead)
        {
            return "computed";
        }

        object? value;
        try { value = property.GetValue(instance); }
        catch { return "computed"; }
        if (value is null) return "null";
        if (value is string text) return text.Length == 0 ? "\"\"" : $"\"{text}\"";
        if (value is bool boolean) return boolean ? "true" : "false";
        if (value is Enum enumeration) return $"{FriendlyTypeName(value.GetType())}.{enumeration}";
        if (value is double number)
        {
            if (number == double.MinValue) return "double.MinValue";
            if (number == double.MaxValue) return "double.MaxValue";
            return number.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }
        if (value is float single) return single.ToString(System.Globalization.CultureInfo.InvariantCulture);
        if (value is int or long or decimal) return Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture)!;
        if (value is System.Collections.ICollection collection) return collection.Count == 0 ? "empty" : $"{collection.Count} item(s)";
        if (value.GetType().IsValueType) return "default";
        return "computed";
    }

    public static string FormatType(Type type)
    {
        if (Nullable.GetUnderlyingType(type) is Type nullable) return FormatType(nullable) + "?";
        if (type.IsGenericParameter) return type.Name;
        if (type.IsArray) return FormatType(type.GetElementType()!) + "[]";
        if (type.IsGenericType)
        {
            string name = type.GetGenericTypeDefinition().Name.Split('`')[0];
            return name + "<" + string.Join(", ", type.GetGenericArguments().Select(FormatType)) + ">";
        }

        return type == typeof(string) ? "string" :
            type == typeof(bool) ? "bool" :
            type == typeof(int) ? "int" :
            type == typeof(double) ? "double" :
            type == typeof(float) ? "float" :
            type == typeof(object) ? "object" :
            type == typeof(void) ? "void" : type.Name;
    }

    private static string FriendlyTypeName(Type? type)
        => type is null ? "none" : FormatType(type);

    private static Type CloseGeneric(Type type)
        => type.IsGenericTypeDefinition ? type.MakeGenericType(type.GetGenericArguments().Select(_ => typeof(object)).ToArray()) : type;

    private static bool IsBuildPath(string path)
        => path.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase) ||
           path.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase);

    public static string ToPosix(string path) => path.Replace('\\', '/');
}
