using System.Reflection;
using Xunit;
using Microsoft.Extensions.Configuration;
using Moq;
using ZipToInfo.Shared.Settings;

namespace ZipToInfo.Services.Tests
{
    public class SettingsService_Tests
    {
        private SettingsService _settingsService;

        // TODO: this is my first time using XUnit. Nunit has a "setup" attribute use to re-initialize all mocks, etc before a test suite is run.
        // I'm sure XUnit has something similar, but haven't found it yet...

        [Theory]
        [InlineData("GoogleMapsApi_Elevation_Api_Url")]
        [InlineData("GoogleMapsApi_Key")]
        public void Settings_ReturnsExpectedStringSetting(string key)
        {
            var settingValue = $"{key}_Value";

            // need to mock "GetSection", not "GetValue" because GetValue is an extension method (which are all static), and not Moq-able
            // unfortuantely, this reveals too much knowledge of the inner workings of an external DLL, and may be fragile as such
            var mockConfigSection = new Mock<IConfigurationSection>();
            mockConfigSection.Setup(mcs => mcs.Value).Returns(settingValue);
            var mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(mc => mc.GetSection(key)).Returns(mockConfigSection.Object);

            _settingsService = new SettingsService(mockConfig.Object);

            // do some reflection here for flexibility. should only have to define the InlineData when a new setting is added.
            var propInfo = _settingsService.GetType().GetProperty(key, BindingFlags.Public | BindingFlags.Instance);
            Assert.Equal(settingValue, propInfo.GetValue(_settingsService));
        }
    }
}
