namespace JsonLoaderPackage;

public class JsonLoaderService
{
    public static Boolean LoadJson(string filePath)
    {
        Console.WriteLine($"JsonLoaderService.LoadJson() invoked! You have parsed in \"{filePath}\"!");

        return true;
    }
}
