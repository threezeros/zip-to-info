using Xunit;
using Moq;
using ZipToInfo.Data;
using ZipToInfo.Data.Access;
using ZipToInfo.Models;

namespace ZipToInfo.Services.Tests.Data 
{
    public class DataService_Tests
    {
        private DataService _dataService;
        
        [Fact]
        public void DataService_GetInfo_FormatsReturnedObject()
        {
            var mockGoogleMapsClient = new Mock<IGoogleMapsApiClient>();    
            var fakeElevationInfo = new GoogleMapsApi_ElevationInfo 
            {

            };
            var fakeTimeZoneInfo = new GoogleMapsApi_TimeZoneInfo 
            {
                
            };

            var mockOpenWeatherClient = new Mock<IOpenWeatherApiClient>();
            var fakeWeatherInfo = new GoogleMapsApi_TimeZoneInfo 
            {
                
            };

            _dataService = new DataService(mockGoogleMapsClient.Object, mockOpenWeatherClient.Object);

        }
    }
}