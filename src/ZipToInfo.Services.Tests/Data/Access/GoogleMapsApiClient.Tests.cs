using Xunit;
using Moq;
using RestSharp;
using ZipToInfo.Data.Access;
using ZipToInfo.Shared.Settings;

namespace ZipToInfo.Services.Tests.Data.Access 
{
    public class GoogleMapsApiClient_Tests
    {
        private GoogleMapsApiClient _googleClient;
        private ISettingsService _settings;
        private IRestClient _restClient;

        private double latitude = 10.02;
        private double longitude = -10.02;
        private string apiKey = "GoogleMapsAPIKey";

        private string timeZoneUrl = "http://timezone/&latitude={0}&longitude={1}&timestamp={2}&apikey={3}";
        private string elevationUrl = "http://elevation/&latitude={0}&longitude={1}&apikey={2}";

        [Fact]
        public void GoogleMapsApi_Timezone_ExecuteCallsExpectedUrl()
        {
            var mockSettings = new Mock<ISettingsService>();
            mockSettings.Setup(s => s.GoogleMapsApi_Key).Returns(apiKey);
            mockSettings.Setup(s => s.GoogleMapsApi_TimeZone_Api_Url).Returns(timeZoneUrl);

            var mockClient = new Mock<IRestClient>();
            mockClient.Setup(cli => cli.Get(It.IsAny<IRestRequest>())).Returns(AccessTestsHelper.GetFakeRestResponse());
            
            _googleClient = new GoogleMapsApiClient(mockClient.Object, mockSettings.Object);
            _googleClient.GetTimeZoneInfo(latitude, longitude);

            var url = mockClient.Object.BaseUrl.ToString();

            Assert.Contains($"&latitude={latitude}", url);
            Assert.Contains($"&longitude={longitude}", url);
            Assert.Contains($"&apiKey={apiKey}", url);

            // TODO: this has revealed a (small) design error... we can't test for timestamp... we should pass the timestamp into the GetTimeZoneInfo method
            // isn't that what tests are about?
        }

        [Fact]
        public void GoogleMapsApi_Elevation_ExecuteCallsExpectedUrl()
        {
            var mockSettings = new Mock<ISettingsService>();
            mockSettings.Setup(s => s.GoogleMapsApi_Key).Returns(apiKey);
            mockSettings.Setup(s => s.GoogleMapsApi_Elevation_Api_Url).Returns(elevationUrl);

            var mockClient = new Mock<IRestClient>();
            mockClient.Setup(cli => cli.Get(It.IsAny<IRestRequest>())).Returns(AccessTestsHelper.GetFakeRestResponse());
            
            _googleClient = new GoogleMapsApiClient(mockClient.Object, mockSettings.Object);
            _googleClient.GetElevationInfo(latitude, longitude);

            var url = mockClient.Object.BaseUrl.ToString();

            Assert.Contains($"&latitude={latitude}", url);
            Assert.Contains($"&longitude={longitude}", url);
            Assert.Contains($"&apiKey={apiKey}", url);
        }

        [Fact]
        public void GoogleMapsApi_Elevation_ThrowsError_OnRestClientError()
        {

        }

        [Fact]
        public void GoogleMapsApi_Elevation_ThrowsError_OnServiceError()
        {

        }

        [Fact]
        public void GoogleMapsApi_Timezone_ThrowsError_OnRestClientError()
        {

        }

        [Fact]
        public void GoogleMapsApi_TimeZone_ThrowsError_OnServiceError()
        {
            
        }
    }
}