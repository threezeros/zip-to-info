using Microsoft.Extensions.Configuration;

namespace ZipToInfo.Shared.Settings 
{
    public class SettingsService : ISettingsService
    {
        private readonly IConfiguration _configuration;

        public SettingsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GoogleMapsApi_Elevation_Api_Url => GetSetting<string>("GoogleMapsApi_Elevation_Api_Url");
        public string GoogleMapsApi_Key => GetSetting<string>("GoogleMapsApi_Key");
        public string GoogleMapsApi_TimeZone_Api_Url => GetSetting<string>("GoogleMapsApi_TimeZone_Api_Url");
        public string OpenWeatherApi_AppId => GetSetting<string>("OpenWeatherApi_AppId");
        public string OpenWeatherApi_CurrentWeather_Api_Url => GetSetting<string>("OpenWeatherApi_CurrentWeather_Api_Url");
        
        // at some point, application level caching might be a good idea?
        private T GetSetting<T>(string key)
        {
            return _configuration.GetValue<T>(key);
        }
    }
}