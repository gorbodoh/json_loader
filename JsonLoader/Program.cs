using System;
using JsonLoaderPackage;

namespace JsonLoader
{
    public class Program
    {
        static void Main(string[] args)
        {
            Boolean isJsonLoaderOk = false;

            // Standard hello world.
            Console.WriteLine("Hello World!");

            isJsonLoaderOk = JsonLoaderService.LoadJson("TEST!");
            if (isJsonLoaderOk)
            {
                Console.WriteLine("Everything is fine!");
            }
            else
            {
                Console.WriteLine("Not fine! Not fine!");
            }

            return;
        }
    }
}