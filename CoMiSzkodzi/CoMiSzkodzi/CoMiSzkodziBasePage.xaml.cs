using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using FreshMvvm;
using Xamarin.Forms.Xaml;

namespace CoMiSzkodzi
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CoMiSzkodziBasePage : ContentView
	{
    
		public CoMiSzkodziBasePage ()
		{
			InitializeComponent ();
            //TitleLabel.Text = Tytul;
		}

       
    
    }
}