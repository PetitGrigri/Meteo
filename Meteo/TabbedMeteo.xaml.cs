using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Meteo
{
	public partial class TabbedMeteo : TabbedPage
	{
		public TabbedMeteo()
		{
			InitializeComponent();

			//ajout des sous-page de notre TabbedPage
			Children.Add(new MeteoPage());
			Children.Add(new PrevisionPage());
		}
	}
}
