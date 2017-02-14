using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Meteo
{
	public class OpenweathermapAPI
	{

		//l'url de l'API
		const string url = "http://api.openweathermap.org/data/2.5";

		//l'apiID nécessaire à l'utilisation de l'API openweathermap
		const string apiToken = "3501b556e362179e3346e72f158df909";

		//La options que l'on utilisera pour les requêtes
		const string language 			= "fr";			//langue à utiliser
		const string uniteTemperature 	= "metric";		//unité pour la température

		/// <summary>
		/// Permet de récupérer les informations météorologique précise d'une ville
		/// </summary>
		/// <returns>The meteo ville.</returns>
		/// <param name="ville">Ville.</param>
		public async Task<MeteoData> getMeteoVille(String ville)
		{
			//création d'un client
			HttpClient client = new HttpClient();
			String stringRequete = "";

			//toujours mettre un try catch, quand on utilise une ressource qui ne nous appartient pas 
			try
			{
				//création de l'url qui va être envoyer pour récupérer les données de la ville
				string urlVille = url + "/weather?q="+ville+"&lang="+language+"&units="+uniteTemperature+"&APPID=" + apiToken;

				//récupération du contenu de la requête
				stringRequete = await client.GetStringAsync(urlVille);

				//conversion de notre stringRequete en objet JSON se basant sur MEteoData (Lui même se basant sur d'autre Model *****Data) puis retour
				return JsonConvert.DeserializeObject<MeteoData>(stringRequete);

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Erreur GetClient : " + ex.Message);
				throw ex;
			}
		}

		/// <summary>
		/// Permet de récupérer les informations prévisionelles d'une
		/// </summary>
		/// <returns>The historique meteo ville.</returns>
		/// <param name="ville">Ville.</param>
		public async Task<HistoriqueData> getHistoriqueMeteoVille(String ville)
		{
			//création d'un client
			HttpClient client = new HttpClient();
			String stringRequete = "";

			//toujours mettre un try catch, quand on utilise une ressource qui ne nous appartient pas 
			try
			{
				//création de l'url qui va être envoyer pour récupérer les données de la ville
				string urlVille = url + "/forecast?q=" + ville + "&lang=" + language + "&units=" + uniteTemperature + "&APPID=" + apiToken;

				//récupération du contenu de la requête
				stringRequete = await client.GetStringAsync(urlVille);

				//conversion de notre stringRequete en objet JSON se basant sur Historique (Lui même se basant sur d'autre Model *****Data) puis retour
				return JsonConvert.DeserializeObject<HistoriqueData>(stringRequete);

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Erreur GetClient : " + ex.Message);
				throw ex;
			}
		}
	}
}
