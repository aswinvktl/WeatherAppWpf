using System;
using System.Windows;

namespace WeatherAppWpf
{
    public partial class MainWindow : Window
    {
        private readonly WeatherService weatherService = new WeatherService(); // Initialize WeatherService

        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the Find button
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Fetch weather data
                string location = LocationBox.Text;

                if (string.IsNullOrWhiteSpace(location))
                {
                    WeatherDetails.Text = "Please enter a valid location.";
                    return;
                }

                // Call WeatherService to fetch weather data
                var weatherData = await weatherService.ApiCallerAsync(location);

                // Display the weather details
                WeatherDetails.Text = $"City: {weatherData.name}\n" +
                                      $"Temperature: {weatherData.main.temp}°C\n" +
                                      $"Feels Like: {weatherData.main.feels_like}°C\n" +
                                      $"Description: {weatherData.weather[0].description}\n" +
                                      $"Wind Speed: {weatherData.wind.speed} m/s";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                WeatherDetails.Text = $"Unexpected error: {ex.Message}";
            }
        }
    }
}
