using System;

namespace ZipToInfo.Models
{
    public class ZipInfo
    {
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public double CurrentTemperatureFahrenheit { get; set; }
        public TimeZoneInfo TimeZone { get; set; }
        public double ElevationInFeet { get; set; }
    }
}