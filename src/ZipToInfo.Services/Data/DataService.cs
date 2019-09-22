using System;
using System.Linq;
using ZipToInfo.Models;
using ZipToInfo.Data.Access;

namespace ZipToInfo.Data
{
    public class DataService : IDataService
    {
        private readonly IOpenWeatherApiClient _openWeatherApiClient;
        private readonly IGoogleMapsApiClient _googleMapsApiClient;

        public DataService(IGoogleMapsApiClient googleMapsApi, IOpenWeatherApiClient openWeatherApi)
        {
            _googleMapsApiClient = googleMapsApi;
            _openWeatherApiClient = openWeatherApi;
        }

        public ZipInfo GetInfoForZip(string zipCode)
        {
            var weather = _openWeatherApiClient.GetWeather(zipCode);
            // a useful "side effect" of getting the weather API is that it also returns 
            // lat and long, required for the google calls...
            var timezone = _googleMapsApiClient.GetTimeZoneInfo(weather.Coord.Lat, weather.Coord.Lon);
            var elevation = _googleMapsApiClient.GetElevationInfo(weather.Coord.Lat, weather.Coord.Lon);

            var zipInfo = new ZipInfo {
                CityName = weather.Name,
                CurrentTemperatureFahrenheit = weather.Main.Temp,
                ElevationInFeet = elevation.Results.FirstOrDefault()?.Elevation ?? 0,
                TimeZone = timezone.TimeZoneName != null ? TimeZoneInfo.FromSerializedString(timezone.TimeZoneName) : TimeZoneInfo.Local,
                ZipCode = zipCode
            };
            
            return zipInfo; 
        }
    }
}