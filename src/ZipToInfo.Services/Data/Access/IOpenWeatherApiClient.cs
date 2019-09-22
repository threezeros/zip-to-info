using ZipToInfo.Models;

namespace ZipToInfo.Data.Access
{
    public interface IOpenWeatherApiClient
    {
         OpenWeatherApi_Weather GetWeather(string zipCode, string countryCode="us");
    }
}