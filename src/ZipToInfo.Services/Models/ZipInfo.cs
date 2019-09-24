using System;

namespace ZipToInfo.Models
{
    public class ZipInfo
    {
        public string CityName { get; set; }
        public double CurrentTemperatureFahrenheit { get; set; }
        public double? ElevationInFeet { get; set; }
        public string TimeZone { get; set; }
        public string ZipCode { get; set; }

        // note: I normally probably wouldn't put string formatting into a POCO like this, but it does cleanup the controller a bit
        public override string ToString()
        {
            var na = "[Not Available]";
            return $"At the location {CityName} ({ZipCode}), the temperature is {CurrentTemperatureFahrenheit} &deg;F, the timezone is {TimeZone ?? na}, and the elevation is {ElevationInFeet?.ToString() ?? na} ft.";
        }
    }
}