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
	public partial class SobotaPage : ContentPage
	{
		public SobotaPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}