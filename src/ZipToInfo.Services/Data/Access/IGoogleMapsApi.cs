using ZipToInfo.Models;

namespace ZipToInfo.Data.Access
{
    public interface IGoogleMapsApi
    {
        GoogleMapsApi_ElevationInfo GetElevationInfo(double latitude, double longitude);
        
        GoogleMapsApi_TimeZoneInfo GetTimeZoneInfo(double latitude, double longitude);
    }
}