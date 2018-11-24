using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoMiSzkodzi
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InformacjePage : ContentPage
	{
		public InformacjePage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            Informations.Text = "Blabla bla bla bla bla bla bla bla bla bla bla " +
                                "Cos tam cos tam cos tam cos tam " +
                                "puta barca milan glory glory man united";
        }
	}
}