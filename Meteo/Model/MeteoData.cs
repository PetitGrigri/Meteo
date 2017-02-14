using System;
using System.Collections.Generic;

namespace Meteo
{
	public class MeteoData
	{

		public int id { get; set; }
		public string name { get; set; }
		public string cod { get; set; }
		public List<WeatherData> weather { get; set; }
		public WindData wind { get; set; }
		public MainData main { get; set; }
	}
}

/*


{
  "coord": {
    "lon": 2.35,
    "lat": 48.85
  },
  "weather": [
    {
      "id": 500,
      "main": "Rain",
      "description": "light rain",
      "icon": "10d"
    }
  ],
  "base": "stations",
  "main": {
    "temp": 280.786,
    "pressure": 1024.26,
    "humidity": 89,
    "temp_min": 280.786,
    "temp_max": 280.786,
    "sea_level": 1036.7,
    "grnd_level": 1024.26
  },
  "wind": {
    "speed": 5.12,
    "deg": 131.003
  },
  "rain": {
    "3h": 0.2
  },
  "clouds": {
    "all": 92
  },
  "dt": 1487061590,
  "sys": {
    "message": 0.0088,
    "country": "FR",
    "sunrise": 1487055581,
    "sunset": 1487092232
  }
}*/