using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace Meteo
{
	public partial class MeteoPage : ContentPage
	{
		private OpenweathermapAPI api;

		/// <summary>
		/// Contructeur de la page des prévision, il nous permettra de créer notre OpenweaterAPI
		/// </summary>
		public MeteoPage()
		{
			InitializeComponent();
			api = new OpenweathermapAPI();
		}

		/// <summary>
		/// Cette méthode est appeller lorsque l'utilisateur à valider la saisie d'une ville pour afficher la météo d'une ville
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		async void getMeteoVille(object sender, EventArgs e)
		{
			//récupération de la saisie de l'utilisateur
			String nomVille = nom.Text;

			//si on a une ville
			if ((nomVille != null) && (nomVille.ToString().Length > 0))
			{
				//affichage du chargement (un label)
				loadingLabel.IsVisible = true;

				//recherche de la météo de la ville via l'API
				MeteoData meteoVille = await api.getMeteoVille(nom.Text);

				//on cache le loading 
				loadingLabel.IsVisible = false;

				//on remplis l'UI avec les informations qu'on a récupéré
				villeLabel.Text 		= meteoVille.name;
				descriptionWeather.Text = meteoVille.weather[0].description;
				imageWeather.Source 	= new Uri("http://openweathermap.org/img/w/"+meteoVille.weather[0].icon+".png");
				temperatureLabel.Text 	= "" + meteoVille.main.temp +"°C";
				humidityLabel.Text 		= "" + meteoVille.main.humidity+ "%";
				windSpeedLabel.Text 	= "" + (meteoVille.wind.speed * 3600 / 1000) + " km/h";
				//WindUtility convertDirection  permet de convertir l'angle du vent en indication litterale (SUD OUET par exemple)
				windDirection.Text 		= WindUtility.convertDirection(meteoVille.wind.deg) + " (" +meteoVille.wind.deg+"° )";

				//on affiche les données retournées
				frameVille.IsVisible = true;
			}
			else {
				//affichage d'une alerte si la ville n'est pas remplie
				DisplayAlert("Attention", "Vous n'avez pas saisis votre ville", "Ok");
			}

		}
	}
}
