using ZipToInfo.Models;
using ZipToInfo.Data.Access;

namespace ZipToInfo.Data
{
    public class DataService
    {
        private readonly IOpenWeatherApi _openWeatherApi;
        private readonly IGoogleMapsApi _googleMapsApi;

        public DataService(IOpenWeatherApi openWeatherApi, IGoogleMapsApi googleMapsApi)
        {
            _openWeatherApi = openWeatherApi;
            _googleMapsApi = googleMapsApi;
        }

        public ZipInfo GetInfoForZip(string zipCode)
        {
            var weather = _openWeatherApi.GetWeather(zipCode);
            // a useful side effect of getting the weather API is that it also returns 
            // lat and long, required for the google calls...

            var timezone = _googleMapsApi.GetTimeZoneInfo(weather.Coord.Lat, weather.Coord.Lon);
            var elevation = _googleMapsApi.GetElevationInfo(weather.Coord.Lat, weather.Coord.Lon);

            var zipInfo = new ZipInfo {
                ZipCode = zipCode, 
                CityName = weather.Name,
                CurrentTemperatureFahrenheit = KelvinToFahrenheit(weather.Main.Temp),


            };
            
            return zipInfo; 
        }

        public double KelvinToFahrenheit(double kelvin)
        {
            return 9 / 5 * (kelvin - 273) + 32;
        }
    }
}