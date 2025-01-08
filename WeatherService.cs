using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAppWpf
{
    internal class WeatherService
    {
        private const string basicURL = "https://api.openweathermap.org/data/2.5/weather";

        // Hardcoded API Key
        private const string ApiKey = "bbe2a48a3c48069f24804afb37b25f06"; // Replace with your actual API key

        // Helper method to build the complete API URL
        public string BuildUrl(string location)
        {
            return $"{basicURL}?q={location}&appid={ApiKey}&units=metric";
        }

        // Asynchronous method to make the API call
        public async Task<WeatherData> ApiCallerAsync(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException("Location cannot be empty!");
            }

            string apiUrl = BuildUrl(location);
            Console.WriteLine($"Generated API URL: {apiUrl}");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Raw JSON Data: {jsonData}");

                        // Parse JSON into WeatherData object
                        WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonData);

                        return weatherData;
                    }
                    else
                    {
                        throw new Exception($"API call failed with status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
