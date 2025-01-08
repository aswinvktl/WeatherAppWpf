using System.Collections.Generic;

namespace WeatherAppWpf
{
    public class WeatherData
    {
        // properties to store the values
        public Coordinate coord { get; set; } // Coordinates (latitude and longitude)
        public List<Weather> weather { get; set; } // Weather conditions
        public Main main { get; set; } // Temperature, pressure, etc.
        public Wind wind { get; set; } // Wind data
        public string name { get; set; } // City name
    }

    // now we explore the properties
    public class Coordinate
    {
        public double lat { get; set; } // Latitude
        public double lon { get; set; } // Longitude
    }

    public class Weather
    {
        public string main { get; set; } // Main weather condition (e.g., Clear, Clouds)
        public string description { get; set; } // Detailed description (e.g., clear sky)
    }

    public class Main
    {
        public double temp { get; set; } // Temperature
        public double feels_like { get; set; } // Feels-like temperature
        public int pressure { get; set; } // Pressure in hPa
        public int humidity { get; set; } // Humidity in %
    }

    public class Wind
    {
        public double speed { get; set; } // Wind speed
        public int deg { get; set; } // Wind direction in degrees
    }
}
