using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FreshMvvm;

namespace CoMiSzkodzi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

    }
}
