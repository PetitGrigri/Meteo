using System;
namespace Meteo
{
	public class HistoriqueListeData
	{
		public string temperature { get; set; }
		public string description { get; set; }
		public DateTime dt_txt { get; set; }
		public Uri iconUri { get; set; }
	}
}
