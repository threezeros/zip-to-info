using System;
using System.Collections.Generic;

namespace ZipToInfo.Models
{
    public class OpenWeatherApi_Weather
    {
        /*
        sample JSON according to : https://openweathermap.org/current
            {
                "coord": {"lon": -122.08,"lat": 37.39},
                "weather": [
                    {
                    "id": 800,
                    "main": "Clear",
                    "description": "clear sky",
                    "icon": "01d"
                    }
                ],
                "base": "stations",
                "main": {
                    "temp": 296.71,
                    "pressure": 1013,
                    "humidity": 53,
                    "temp_min": 294.82,
                    "temp_max": 298.71
                },
                "visibility": 16093,
                "wind": {
                    "speed": 1.5,
                    "deg": 350
                },
                "clouds": {
                    "all": 1
                },
                "dt": 1560350645,
                "sys": {
                    "type": 1,
                    "id": 5122,
                    "message": 0.0139,
                    "country": "US",
                    "sunrise": 1560343627,
                    "sunset": 1560396563
                },
                "timezone": -25200,
                "id": 420006353,
                "name": "Mountain View",
                "cod": 200
                }
         */

        public OpenWeatherApi_Coordinates Coord { get; set; }
        public List<OpenWeatherApi_WeatherDetails> Weather { get; set; }
        public string Base { get; set; }
        public OpenWeatherApi_Main Main { get; set; }
        public int Visibility { get; set; }
        public OpenWeatherApi_Wind Wind { get; set; }
        public OpenWeatherApi_Clouds Clouds { get; set; }
        public Int64 Dt { get; set; }
        public OpenWeatherApi_Sys Sys { get; set; }
        public Int64 Timezone { get; set; }
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class OpenWeatherApi_Coordinates
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class OpenWeatherApi_WeatherDetails 
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class OpenWeatherApi_Main
    {
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity  { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
    }

    public class OpenWeatherApi_Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }

    public class OpenWeatherApi_Clouds
    {
        public int All { get; set; }
    }

    public class OpenWeatherApi_Sys
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public double Message { get; set; }
        public string Country { get; set; }
        public Int64 Sunrise { get; set; }
        public Int64 Sunset { get; set; }
    }
}