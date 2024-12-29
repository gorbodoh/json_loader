using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace JsonLoader
{
    public partial class Program
    {
        static async Task Main(string[] args)
        {
            // The important parameters to be used.
            const string filePath = "TestData/posts.json";
            const string uri = "https://jsonplaceholder.typicode.com";

            // Standard hello world.
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            // Load Json file as string.
            LoadJsonAsString(filePath);

            // This website provides lots of Json datasets for testing: https://jsonplaceholder.typicode.com
            // await LoadJsonHTTP(uri);
        }

        /**
         * A small private function to test System.Net.Http.Json.
         */
        private static async Task LoadJsonHTTP(string uri)
        {
            Console.WriteLine("LoadJsonHttp() invoked! Starting function...");
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
            Console.WriteLine();

            return;
        }

        /**
         * A small private function to showcase loading Json file as a string.
         */
        private static void LoadJsonAsString(string filePath)
        {
            Console.WriteLine($"LoadJsonAsString() invoked! Starting function...");
            using JsonDocument jsonDocument = JsonDocument.Parse(File.ReadAllText(filePath), default);
            JsonElement root = jsonDocument.RootElement;

            foreach (JsonProperty jsonProperty in root.EnumerateObject())
            {
                Console.WriteLine($"Property Name: {jsonProperty.Name}");
                Console.WriteLine($"Property Value: {jsonProperty.Value}");
            }
            Console.WriteLine();

            return;
        }
    }
}