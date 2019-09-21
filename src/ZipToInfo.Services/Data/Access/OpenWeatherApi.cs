using System;
using RestSharp;
using ZipToInfo.Models;
using ZipToInfo.Shared.Settings;


namespace ZipToInfo.Data.Access
{
    public class OpenWeatherApi : IOpenWeatherApi
    {
        private readonly ISettingsService _settingsService;

        public OpenWeatherApi(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
         
        public OpenWeatherApi_Weather GetWeather(string zipCode)
        {
            // TODO: error handling and reporting
            // TODO: see note in GoogleMapsApi for RestSharp support of Rest calls
            var client = new RestClient(OpenWeatherUrl(zipCode));
            var request = new RestRequest();
            var response = client.Get<OpenWeatherApi_Weather>(request);

            if (response.ErrorException != null)
            {
                // TODO: log and report error
                throw new Exception("Error getting weather information", response.ErrorException);
            }

            return response.Data;       
        }

        private string OpenWeatherUrl(string zipCode)
        {
            return string.Format(_settingsService.OpenWeatherApi_Weather_Api_Url, zipCode);
        }
    }
}