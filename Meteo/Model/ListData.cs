using System;
using System.Collections.Generic;

namespace Meteo
{
	public class ListData
	{
		public DateTime dt_txt { get; set; }
		public List<WeatherData> weather { get; set; }
		public WindData wind { get; set; }
		public MainData main { get; set; }

	}
}
