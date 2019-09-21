namespace ZipToInfo.Models
{
    public class GoogleMapsApi_TimeZoneInfo
    {
        /*
        sample response JSON according to: https://developers.google.com/maps/documentation/timezone/start?hl=en_US
        {
            "dstOffset" : 3600,
            "rawOffset" : -18000,
            "status" : "OK",
            "timeZoneId" : "America/New_York",
            "timeZoneName" : "Eastern Daylight Time"
        }
         */

        public int DstOffset { get; set; }
        public int RawOffset { get; set; }
        public string Status { get; set; }
        public string TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }
    }
}