namespace OkfDocsValidator;

public static class SelfTests
{
    public static int Run()
    {
        List<string> failures = [];
        Assert(!RepositoryValidator.TryReadFrontmatter("# Missing", out _, out _), "missing frontmatter", failures);
        Assert(!RepositoryValidator.TryReadFrontmatter("---\ntype: [broken\n---\n", out _, out _), "malformed YAML", failures);
        Assert(RepositoryValidator.FindUnknownTokens("color: var(--bad-Token);", ["--good-Token"]).SequenceEqual(["--bad-Token"]), "unknown token", failures);
        Assert(RepositoryValidator.FindMissingComponentPages(["Example.A", "Example.B"], ["Example.A"]).SequenceEqual(["Example.B"]), "missing component page", failures);

        ComponentContract sample = new(
            "Sample", "Example.Sample", "Sample", "Sample.razor", "Example", [], "ComponentBase",
            [
                new ParameterContract("Value", "string", "null", "No", "@bind-Value", "Sample"),
                new ParameterContract("ValueChanged", "EventCallback<string>", "default", "No", "-", "Sample")
            ], [], ["Sample.razor"], [], [], []);
        Dictionary<string, List<ComponentContract>> components = new(StringComparer.Ordinal) { ["Sample"] = [sample] };
        Assert(RepositoryValidator.ValidateExampleSnippet("<Sample Unknown=\"x\" />", sample.FullName, components).Count == 1, "invalid example attribute", failures);
        Assert(RepositoryValidator.ValidateExampleSnippet("<Sample @bind-Missing=\"value\" />", sample.FullName, components).Count == 1, "broken binding", failures);
        Assert(RepositoryValidator.ValidateExampleSnippet("<Sample @bind-Value=\"value\" />", sample.FullName, components).Count == 0, "valid binding", failures);

        string staleTable = "<!-- parameters:start -->\n| Name | Type | Default | Required | Binding | Declared by | Notes |\n|---|---|---|---|---|---|---|\n| `Value` | `string` | `null` | No | `@bind-Value` | `Sample` | Current |\n| `Removed` | `bool` | `false` | No | `-` | `Sample` | Stale |\n<!-- parameters:end -->";
        Assert(RepositoryValidator.FindUnknownDocumentedParameters(staleTable, sample.Parameters, "parameters").SequenceEqual(["Removed"]), "stale parameter", failures);

        string temporaryRoot = Path.Combine(Path.GetTempPath(), "okf-validator-self-test-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(temporaryRoot);
        try
        {
            string page = Path.Combine(temporaryRoot, "page.md");
            string existing = Path.Combine(temporaryRoot, "existing.md");
            File.WriteAllText(page, "# Page");
            File.WriteAllText(existing, "# Existing");
            Assert(RepositoryValidator.LocalLinkExists(page, "existing.md", temporaryRoot), "valid local link", failures);
            Assert(!RepositoryValidator.LocalLinkExists(page, "missing.md", temporaryRoot), "broken local link", failures);
        }
        finally
        {
            Directory.Delete(temporaryRoot, recursive: true);
        }

        if (failures.Count > 0)
        {
            foreach (string failure in failures) Console.Error.WriteLine("Self-test failed: " + failure);
            return 1;
        }

        Console.WriteLine("OKF validator self-tests passed (YAML, coverage, parameter, binding, example, token, and link checks).");
        return 0;
    }

    private static void Assert(bool condition, string name, List<string> failures)
    {
        if (!condition) failures.Add(name);
    }
}
