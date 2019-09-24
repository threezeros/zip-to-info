using Xunit;
using Moq;
using RestSharp;
using ZipToInfo.Data.Access;
using ZipToInfo.Shared.Settings;

namespace ZipToInfo.Services.Tests.Data.Access 
{
    public class OpenWeatherApiClient_Tests
    {
        private OpenWeatherApiClient _owClient;
        private ISettingsService _settings;
        private IRestClient _restClient;

        private string zipCode = "abcde";
        private string countryCode = "12";
        private string apiKey = "OWAPIKey";

        private string weatherUrl = "http://timezone/&zipCode={0}&countryCode={1}&apikey={2}";


        [Fact]
        public void OpenWeather_Weather_ExecuteCallsExpectedUrl()
        {
            var mockSettings = new Mock<ISettingsService>();
            mockSettings.Setup(s => s.OpenWeatherApi_AppId).Returns(apiKey);
            mockSettings.Setup(s => s.OpenWeatherApi_CurrentWeather_Api_Url).Returns(weatherUrl);

            var mockClient = new Mock<IRestClient>();
            mockClient.Setup(cli => cli.Get(It.IsAny<IRestRequest>())).Returns(AccessTestsHelper.GetFakeRestResponse());

            _owClient = new OpenWeatherApiClient(mockClient.Object, mockSettings.Object);
            _owClient.GetWeather(zipCode, countryCode);

            var url = mockClient.Object.BaseUrl.ToString();

            Assert.Contains($"&zipCode={zipCode}", url);
            Assert.Contains($"&countryCode={countryCode}", url);
            Assert.Contains($"&apiKey={apiKey}", url);
        }

        [Fact]
        public void OpenWeather_Weather_ExecuteCallsExpectedUrl_WithDefaultCountryCode()
        {
            var mockSettings = new Mock<ISettingsService>();
            mockSettings.Setup(s => s.OpenWeatherApi_AppId).Returns(apiKey);
            mockSettings.Setup(s => s.OpenWeatherApi_CurrentWeather_Api_Url).Returns(weatherUrl);

            var mockClient = new Mock<IRestClient>();
            mockClient.Setup(cli => cli.Get(It.IsAny<IRestRequest>())).Returns(AccessTestsHelper.GetFakeRestResponse());
            
            _owClient = new OpenWeatherApiClient(mockClient.Object, mockSettings.Object);
            _owClient.GetWeather(zipCode);

            var url = mockClient.Object.BaseUrl.ToString();

            Assert.Contains($"&zipCode={zipCode}", url);
            Assert.Contains($"&countryCode=us", url);
            Assert.Contains($"&apiKey={apiKey}", url);
        }

        [Fact]
        public void OpenWeatherApi_Weather_ThrowsError_OnRestClientError()
        {

        }
    }
}