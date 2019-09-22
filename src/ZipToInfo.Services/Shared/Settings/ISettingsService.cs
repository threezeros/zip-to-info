using System;

namespace ZipToInfo.Shared.Settings 
{
    public interface ISettingsService
    {
        string GoogleMapsApi_Elevation_Api_Url { get; }
        string GoogleMapsApi_Key { get; }
        string GoogleMapsApi_TimeZone_Api_Url { get; }
        string OpenWeatherApi_CurrentWeather_Api_Url { get; }
        string OpenWeatherApi_AppId { get; }
    }
}