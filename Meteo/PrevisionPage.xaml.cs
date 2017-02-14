using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Meteo
{
	public partial class PrevisionPage : ContentPage
	{
		private OpenweathermapAPI api;

		/// <summary>
		/// Contructeur de la page des prévision, il nous permettra de créer notre OpenweaterAPI
		/// </summary>
		public PrevisionPage()
		{
			InitializeComponent();
			api = new OpenweathermapAPI();
		}

		/// <summary>
		/// Cette méthode est appeller lorsque l'utilisateur à valider la saisie d'une ville pour afficher les prévisions
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		async void getHistoriqueMeteoVille(object sender, EventArgs e)
		{
			//récupération de la saisie de l'utilisateur
			String nomVille = nom.Text;

			//si on a une ville
			if ((nomVille != null) && (nomVille.ToString().Length > 0))
			{
				//affichage/masquage de certains éléments de l'UI
				listePrevision.IsVisible 			= false;
				loadingHistoriqueLabel.IsVisible 	= true;
				villeHistoriqueLabel.IsVisible 		= false;

				//recherche de la météo de la ville
				HistoriqueData meteoHistoriqueVille = await api.getHistoriqueMeteoVille(nom.Text);

				//création d'une liste qui sera remplis avec les données nécessaire à notre listeView
				List<HistoriqueListeData> listeHistoriqueData = new List<HistoriqueListeData>();

				//A partir de la liste récupérer de notre API, on fait un peu de nettoyage, pour envoyer à la listeView le nécessaire
				//une bonne pratique serait d'utiliser un objet intérmédiaire entre le controller et l'API qui s'occuperait de faire cette action
				foreach (ListData liste in meteoHistoriqueVille.list)
				{
					HistoriqueListeData tempoHLD 	= new HistoriqueListeData();
					tempoHLD.description 			= liste.weather[0].description;
					tempoHLD.temperature			= "" + liste.main.temp + "°C";
					tempoHLD.dt_txt 				= liste.dt_txt;
					tempoHLD.iconUri				= new Uri("http://openweathermap.org/img/w/" + liste.weather[0].icon + ".png");

					listeHistoriqueData.Add(tempoHLD);
				}

				//Affichage de la ville trouvé et envois de notre liste d'élément à notre listeVIew
				villeHistoriqueLabel.Text 	= meteoHistoriqueVille.city.name;
				listePrevision.ItemsSource 	= listeHistoriqueData;

				//affichage/masquage de certains éléments de l'UI
				listePrevision.IsVisible 			= true;
				loadingHistoriqueLabel.IsVisible 	= false;
				villeHistoriqueLabel.IsVisible 		= true;


			}
			else {
				//affichage d'une alerte si la ville n'est pas remplie
				DisplayAlert("Attention", "Vous n'avez pas saisis votre ville", "Ok");
			}
		}
	}
}
