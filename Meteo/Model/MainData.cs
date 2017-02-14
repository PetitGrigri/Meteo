using System;
namespace Meteo
{
	public class MainData
	{
		public double temp { get; set; }
		public double pressure { get; set; }
		public double humidity { get; set; }
		public double temp_min { get; set; }
		public double temp_max { get; set; }
		public double sea_level { get; set; }
		public double grnd_level { get; set; }
/*
"main": {
    "temp": 13.24,
    "pressure": 1026.14,
    "humidity": 72,
    "temp_min": 13.24,
    "temp_max": 13.24,
    "sea_level": 1038.36,
    "grnd_level": 1026.14
  }
*/
	}
}
