using System;
using System.Net.Http.Json;
using JsonLoaderPackage;

namespace JsonLoader
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Standard hello world.
            Console.WriteLine("Hello World!");

            // This does nothing yet... needs to implement first.
            JsonLoaderService.LoadJson("TEST");

            // This website provides lots of Json datasets for testing: https://jsonplaceholder.typicode.com
            await LoadJsonHTTP("https://jsonplaceholder.typicode.com");
        }

        /**
         * A small private function to test System.Net.Http.Json.
         */
        private static async Task LoadJsonHTTP(string uri)
        {
            using HttpClient httpClient = new()
            {
                BaseAddress = new Uri(uri)
            };

            List<User>? users = new List<User>();
            users = await httpClient.GetFromJsonAsync<List<User>>("users");

            if (users != null && users.Count > 0)
            {
                foreach (User? user in users)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine($"ID: {user?.Id}");
                    Console.WriteLine($"Name: {user?.Name}");
                    Console.WriteLine($"Username: {user?.Username}");
                    Console.WriteLine($"Email: {user?.Email}");
                    Console.WriteLine($"Address: {user?.Address?.Suite}, {user?.Address?.Street}, {user?.Address?.Zipcode} {user?.Address?.City}");
                    Console.WriteLine($"Geolocation: ({user?.Address?.Geo?.Lat}, {user?.Address?.Geo?.Lng})");
                    Console.WriteLine($"Phone: {user?.Phone}");
                    Console.WriteLine($"Website: {user?.Website}");
                    Console.WriteLine("Company:");
                    Console.WriteLine($"    Name: {user?.Company?.Name}");
                    Console.WriteLine($"    Catch Phrase: {user?.Company?.CatchPhrase}");
                    Console.WriteLine($"    Business: {user?.Company?.Bs}");
                    Console.WriteLine("-------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No data fetched.");
            }
        }
    }
}