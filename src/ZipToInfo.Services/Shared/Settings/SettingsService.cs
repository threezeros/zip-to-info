using System;
using System.Configuration;

namespace ZipToInfo.Shared.Settings 
{
    public class SettingsService : ISettingsService
    {
        // going to go ahead an hardcode these, as they are the only settings for this exercise, 
        // but this class does support config settings if I want to add these later
        public string GoogleMapsApi_Elevation_Api_Url => $"https://maps.googleapis.com/maps/api/elevation/json?locations={0},{1}&key={2}";
        public string GoogleMapsApi_Key => "TBD";
        public string GoogleMapsApi_TimeZone_Api_Url => $"https://maps.googleapis.com/maps/api/timezone/json?location={0},{1}&timestamp={2}&key={3}";
        public string OpenWeatherApi_Weather_Api_Url => "http://api.openweathermap.org/data/2.5/weather?zip={0},us";

        

        public string OpenWeatherUrl(int zip)
        {
            return string.Format(OpenWeatherApi_Weather_Api_Url, zip.ToString());
        }

        // Just in case I want to add config entries...
        private string GetSetting(string key)
        {
            var setting = ConfigurationManager.AppSettings[key];
            return setting;
        }
    }
}