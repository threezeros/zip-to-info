using ZipToInfo.Models;

namespace ZipToInfo.Data.Access
{
    public interface IOpenWeatherApi
    {
         OpenWeatherApi_Weather GetWeather(string zipCode);
    }
}