namespace JsonLoaderPackage;

using System.Text.Json;

public static class JsonLoaderService
{
    public static void LoadJson(string filePath)
    {
        Console.WriteLine($"JsonLoaderService.LoadJson() invoked! You have parsed in \"{filePath}\"!");
    }
}
