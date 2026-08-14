using System.Text.Json;

namespace OkfDocsValidator;

internal static class Program
{
    private static int Main(string[] args)
    {
        string command = args.FirstOrDefault()?.ToLowerInvariant() ?? "check";
        string root = ReadOption(args, "--repo-root") ?? FindRepositoryRoot();

        try
        {
            return command switch
            {
                "check" => RunCheck(root),
                "inventory" => RunInventory(root),
                "self-test" => SelfTests.Run(),
                _ => Usage(command)
            };
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Validator failed: {exception}");
            return 2;
        }
    }

    private static int RunCheck(string root)
    {
        ValidationResult result = RepositoryValidator.Validate(root);
        foreach (string message in result.Messages)
        {
            Console.Error.WriteLine(message);
        }

        if (!result.Success)
        {
            Console.Error.WriteLine($"OKF validation failed with {result.Messages.Count} error(s).");
            return 1;
        }

        Console.WriteLine($"OKF validation passed: {result.ComponentCount} components, {result.ConceptCount} concepts, {result.ThemeTokenCount} theme tokens.");
        return 0;
    }

    private static int RunInventory(string root)
    {
        Inventory inventory = ComponentInventory.Create(root);
        Console.WriteLine(JsonSerializer.Serialize(inventory, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }));
        return 0;
    }

    private static int Usage(string command)
    {
        Console.Error.WriteLine($"Unknown command '{command}'. Use check, inventory, or self-test.");
        return 2;
    }

    private static string? ReadOption(string[] args, string name)
    {
        int index = Array.IndexOf(args, name);
        return index >= 0 && index + 1 < args.Length ? Path.GetFullPath(args[index + 1]) : null;
    }

    private static string FindRepositoryRoot()
    {
        DirectoryInfo? directory = new(Environment.CurrentDirectory);
        while (directory is not null)
        {
            if (Directory.Exists(Path.Combine(directory.FullName, ".git")) &&
                Directory.Exists(Path.Combine(directory.FullName, "docs")))
            {
                return directory.FullName;
            }

            directory = directory.Parent;
        }

        throw new DirectoryNotFoundException("Could not locate the repository root. Pass --repo-root <path>.");
    }
}
