using System;
using System.Collections.Generic;
using CoMiSzkodzi.Databases;
using CoMiSzkodzi.PageModels;
using Xamarin.Forms;

namespace CoMiSzkodzi.Pages
{
    public partial class WeekDayPage : ContentPage
    {
        public WeekDayPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            WeekDayPageModel pageModel = (WeekDayPageModel)BindingContext;
            var product = (Food)mi.CommandParameter;
            ProductsListView.BeginRefresh();
            var result = DatabaseConnection.Connection.DeleteAsync(product);
            result.Wait();
            if (result.IsCompleted)
            {
                pageModel.RefreshList();
                ProductsListView.EndRefresh();
            }
        }

        void SegmentValueChanged(object sender, Plugin.Segmented.Event.SegmentSelectEventArgs e)
        {
            var test = "test";
        }

        void Handle_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            var test = e;
        }
    }
}
