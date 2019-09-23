using System;
using Xunit;
using ZipToInfo.Shared.Settings;
using Moq;
using Microsoft.Extensions.Configuration;

namespace ZipToInfo.Services.Tests
{
    public class SettingsTests
    {
        private SettingsService _settingsService;

        // TODO: this is my first time using XUnit. Nunit has a "setup" attribute use to re-initialize all mocks, etc before a test suite is run.
        // sure would be nice to have one of those here...

        [Fact]
        public void Settings_ReturnsGoogleMapsElevationApi()
        {
            var settingKey = "GoogleMapsApi_Elevation_Api_Url";
            var settingValue = $"{settingKey}_Value";

            var mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(mc => mc.GetValue<string>(settingKey)).Returns(settingValue);

            _settingsService = new SettingsService(mockConfig.Object);

            Assert.Equal(_settingsService.GoogleMapsApi_Elevation_Api_Url, settingValue);
        }

        [Fact]
        public void Settings_ReturnsGoogleMapsTimeZoneApi()
        {
            var settingKey = "GoogleMapsApi_TimeZone_Api_Url";
            var settingValue = $"{settingKey}_Value";

            var mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(mc => mc.GetValue<string>(settingKey)).Returns(settingValue);

            _settingsService = new SettingsService(mockConfig.Object);

            Assert.Equal(_settingsService.GoogleMapsApi_TimeZone_Api_Url, settingValue);
        }

        // etc, for remaining settings
    }
}
