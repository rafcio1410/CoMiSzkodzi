using System;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoMiSzkodzi.Databases;
using System.Collections.Generic;
using CoMiSzkodzi.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CoMiSzkodzi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DatabaseConnection.InitializeDatabase();
            if (!Settings.HasRunBefore)
            {
                PopulateDatabase();
            }
            Page page = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        void PopulateDatabase()
        {
            DatabaseConnection.Connection.CreateTableAsync<Food>();
            List<Food> food = new List<Food>();
            food.Add(new Food { name = "Kurczak", categories = Enums.Categories.Meats, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Mleko", categories = Enums.Categories.Diary, blacklisted = Enums.BlackListed.CanNot });
            food.Add(new Food { name = "Sól", categories = Enums.Categories.Spices, blacklisted = Enums.BlackListed.Check });
            food.Add(new Food { name = "Miód", categories = Enums.Categories.Others, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Kopytka", categories = Enums.Categories.Meals, blacklisted = Enums.BlackListed.Check });
            food.Add(new Food { name = "Sok Pomarańczowy", categories = Enums.Categories.Drinks, blacklisted = Enums.BlackListed.CanNot });
            food.Add(new Food { name = "Marchewka", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.Can });
            DatabaseConnection.Connection.InsertAllAsync(food);
            Settings.HasRunBefore = true;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
