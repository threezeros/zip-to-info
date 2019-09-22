using System;
using RestSharp;
using ZipToInfo.Models;
using ZipToInfo.Shared.Settings;

namespace ZipToInfo.Data.Access
{
    public class GoogleMapsApiClient : WebServiceClient, IGoogleMapsApiClient
    {
        private readonly ISettingsService _settingsService;

        public GoogleMapsApiClient(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public GoogleMapsApi_ElevationInfo GetElevationInfo(double latitude, double longitude)
        {
            // TODO: RestSharp provides much better support for creating Rest requests. 
            //      This should be sufficient for this exercise, but future enhancements could consider using these enhancements.
            //      In addition, we know that we will have multiple requests to the same root, and it's
            //      appropriate to keep the "client" around, modifying the remaining bits of the rest call itself...
            var client = new RestClient(GoogleElevationUrl(latitude, longitude));
            var request = new RestRequest();
            var response = client.Get<GoogleMapsApi_ElevationInfo>(request);
            
            AssertHttpResponse(response);
            return response.Data;
        }

        public GoogleMapsApi_TimeZoneInfo GetTimeZoneInfo(double latitude, double longitude)
        {
            // TODO: see note above for RestSharp support of Rest calls
            var client = new RestClient(GoogleTimeZoneUrl(latitude, longitude, DateTime.Now));
            var request = new RestRequest();
            var response = client.Get<GoogleMapsApi_TimeZoneInfo>(request);
            
            AssertHttpResponse(response);
            return response.Data;
        }

        private string GoogleElevationUrl(double latitude, double longitude)
        {
            return string.Format(_settingsService.GoogleMapsApi_Elevation_Api_Url, latitude.ToString(), longitude.ToString(), _settingsService.GoogleMapsApi_Key);
        }

        private string GoogleTimeZoneUrl(double latitude, double longitude, DateTime timestamp)
        {
            return string.Format(_settingsService.GoogleMapsApi_TimeZone_Api_Url, latitude.ToString(), longitude.ToString(), timestamp.Ticks.ToString(), _settingsService.GoogleMapsApi_Key);
        }
    }
}