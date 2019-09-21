namespace ZipToInfo.Models
{
    public class GoogleMapsApi_ElevationInfo
    {
        public GoogleMapsApi_ElevationInfo_Result[] Results { get; set; }
        public string Status { get; set; }
    }

    public class GoogleMapsApi_ElevationInfo_Result
    {
        public double Elevation { get; set; }
        public GoogleMapsApi_ElevationInfo_Coordinates location { get; set; }
        public double Resolution { get; set; }
    }

    public class GoogleMapsApi_ElevationInfo_Coordinates
    {
        // I wouldn't be surprised if this is used in other Google Map constructs, but for now, 
        // since this is the only (google) place this is used, I'm keeping it a little more specifically named and scoped...
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}