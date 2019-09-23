using Xunit;
using ZipToInfo.Models;

namespace ZipToInfo.Services.Tests.Models
{
    public class ZipInfoTests
    {
        private string cityName = "fred";
        private double temp = 71.0;
        private double elevation = 500.0;
        private string timezone = "east west south central";
        private string zipCode = "123ab";

        [Fact]
        public void ZipInfo_ToString_FormatsExpectedResults()
        {
            var zi = GetDefaultZipInfo();

            var expected = $"At the location {cityName} ({zipCode}), the temperature is {temp} &deg;F, the timezone is {elevation.ToString()}, and the elevation is {elevation.ToString()} ft.";            

            Assert.Equal(expected, zi.ToString());
        }

        [Fact]
        public void ZipInfo_ToString_FormatsExpectedResults_WithNullElevation()
        {
            var zi = GetDefaultZipInfo();
            zi.ElevationInFeet = null;
            
            var expected = $"At the location {cityName} ({zipCode}), the temperature is {temp} &deg;F, the timezone is {elevation.ToString()}, and the elevation is [Not Available] ft.";            
            Assert.Equal(expected, zi.ToString());
        }

        [Fact]
        public void ZipInfo_ToString_FormatsExpectedResults_WithNullTimezone()
        {
            var zi = GetDefaultZipInfo();
            zi.TimeZone = null;

            var expected = $"At the location {cityName} ({zipCode}), the temperature is {temp} &deg;F, the timezone is [Not Available], and the elevation is {elevation.ToString()} ft.";
            Assert.Equal(expected, zi.ToString());            
        }

        private ZipInfo GetDefaultZipInfo()
        {
            return new ZipInfo 
            { 
                CityName = cityName,
                CurrentTemperatureFahrenheit = temp,
                ElevationInFeet = elevation,
                TimeZone = timezone,
                ZipCode = zipCode
            };
        }
    }
}