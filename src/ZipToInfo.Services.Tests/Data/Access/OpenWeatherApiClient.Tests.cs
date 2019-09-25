using Xunit;
using Moq;
using RestSharp;
using ZipToInfo.Data.Access;
using ZipToInfo.Models;
using ZipToInfo.Shared.Settings;
using ZipToInfo.Services.Tests.Shared;

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


        [Fact(Skip="Test is not currently runnable because it is trying to mock a static method.")]
        public void OpenWeather_Weather_ExecuteCallsExpectedUrl()
        {
            var mockSettings = new Mock<ISettingsService>();
            mockSettings.Setup(s => s.OpenWeatherApi_AppId).Returns(apiKey);
            mockSettings.Setup(s => s.OpenWeatherApi_CurrentWeather_Api_Url).Returns(weatherUrl);
            var mockResponse = TestUtils.GetMockRestResponse<OpenWeatherApi_Weather>(null as OpenWeatherApi_Weather);
            var mockClient = new Mock<IRestClient>();
            // note: this fails because I'm trying to moq an extension method. this is probably addressable by mocking 
            //    something downstream(?)
            mockClient.Setup(cli => cli.Get<OpenWeatherApi_Weather>(It.IsAny<IRestRequest>())).Returns(mockResponse);

            _owClient = new OpenWeatherApiClient(mockClient.Object, mockSettings.Object);
            var response = _owClient.GetWeather(zipCode, countryCode);

            var url = mockClient.Object.BaseUrl.ToString();

            Assert.Contains($"&zipCode={zipCode}", url);
            Assert.Contains($"&countryCode={countryCode}", url);
            Assert.Contains($"&apiKey={apiKey}", url);
        }

        [Fact(Skip="Test is not currently runnable because it is trying to mock a static method.")]
        public void OpenWeather_Weather_ExecuteCallsExpectedUrl_WithDefaultCountryCode()
        {
            var mockSettings = new Mock<ISettingsService>();
            mockSettings.Setup(s => s.OpenWeatherApi_AppId).Returns(apiKey);
            mockSettings.Setup(s => s.OpenWeatherApi_CurrentWeather_Api_Url).Returns(weatherUrl);
            var mockResponse = TestUtils.GetMockRestResponse<OpenWeatherApi_Weather>(null as OpenWeatherApi_Weather);
            var mockClient = new Mock<IRestClient>();
            // note: this fails because I'm trying to moq an extension method. this is probably addressable by mocking 
            //    something downstream(?)
            mockClient.Setup(cli => cli.Get<OpenWeatherApi_Weather>(It.IsAny<IRestRequest>())).Returns(mockResponse);

            _owClient = new OpenWeatherApiClient(mockClient.Object, mockSettings.Object);
            var response = _owClient.GetWeather(zipCode);

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