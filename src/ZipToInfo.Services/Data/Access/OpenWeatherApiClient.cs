using System;
using RestSharp;
using RestSharp.Authenticators;
using ZipToInfo.Models;
using ZipToInfo.Shared.Settings;

namespace ZipToInfo.Data.Access
{
    public class OpenWeatherApiClient : WebServiceClient, IOpenWeatherApiClient
    {
        private readonly ISettingsService _settingsService;

        public OpenWeatherApiClient(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
         
        public OpenWeatherApi_Weather GetWeather(string zipCode, string countryCode="us")
        {
            // TODO: see note in GoogleMapsApiClient for RestSharp support of Rest calls
            var client = new RestClient(OpenWeatherUrl(zipCode, countryCode));
            
            var request = new RestRequest();
            var response = client.Get<OpenWeatherApi_Weather>(request);

            AssertHttpResponse(response);
            return response.Data;       
        }

        private string OpenWeatherUrl(string zipCode, string countryCode)
        {
            return string.Format(_settingsService.OpenWeatherApi_CurrentWeather_Api_Url, zipCode, countryCode, _settingsService.OpenWeatherApi_AppId);
        }
    }
}