﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CoMiSzkodzi.Databases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoMiSzkodzi
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PoniedzialekPage : ContentPage
	{
		public PoniedzialekPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            PoniedzialekPageModel pageModel = (PoniedzialekPageModel)BindingContext;
            var product = (Food)mi.CommandParameter;
            ProductsListView.BeginRefresh();
            var result = DatabaseConnection.Connection.DeleteAsync(product);
            result.Wait();
            if(result.IsCompleted)
            {
                pageModel.RefreshList();
                ProductsListView.EndRefresh();
            }
        }

        void SegmentValueChanged(object sender, Plugin.Segmented.Event.SegmentSelectEventArgs e)
        {
            var test = "test";
        }
    }
}