using System;
using RestSharp;
using RestSharp.Authenticators;
using ZipToInfo.Models;
using ZipToInfo.Shared.Settings;

namespace ZipToInfo.Data.Access
{
    public class OpenWeatherApiClient : WebServiceClient, IOpenWeatherApiClient
    {
        private readonly IRestClient _restClient;
        private readonly ISettingsService _settingsService;

        public OpenWeatherApiClient(IRestClient restClient, ISettingsService settingsService)
        {
            _restClient = restClient;
            _settingsService = settingsService;
        }
         
        public OpenWeatherApi_Weather GetWeather(string zipCode, string countryCode="us")
        {
            // TODO: see note in GoogleMapsApiClient for RestSharp support of Rest calls
            _restClient.BaseUrl = new System.Uri(OpenWeatherUrl(zipCode, countryCode));
            var request = new RestRequest();
            var response = _restClient.Get<OpenWeatherApi_Weather>(request);

            AssertHttpResponse(response);
            return response.Data;       
        }

        private string OpenWeatherUrl(string zipCode, string countryCode)
        {
            return string.Format(_settingsService.OpenWeatherApi_CurrentWeather_Api_Url, zipCode, countryCode, _settingsService.OpenWeatherApi_AppId);
        }
    }
}