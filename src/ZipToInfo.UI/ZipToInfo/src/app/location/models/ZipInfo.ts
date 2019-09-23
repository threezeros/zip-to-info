/*
Matches Service side object: ZipInfo.cs

public string CityName { get; set; }
public double CurrentTemperatureFahrenheit { get; set; }
public double? ElevationInFeet { get; set; }
public string TimeZone { get; set; }
public string ZipCode { get; set; }
*/

export class ZipInfo {
  cityName: string;
  currentTemperatureFahrenheit?: number;
  elevationInFeet?: number;
  timeZone: string;
  zipCode: string;
}
