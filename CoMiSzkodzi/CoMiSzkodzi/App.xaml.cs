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
            food.Add(new Food { name = "Kurczak", categories = Enums.Categories.Meats, blacklisted = false });
            food.Add(new Food { name = "Sok jabłkowy", categories = Enums.Categories.Drinks, blacklisted = false });
            food.Add(new Food { name = "Ser żółty", categories = Enums.Categories.Diary, blacklisted = false });
            food.Add(new Food { name = "Chipsy Lays", categories = Enums.Categories.Snacks, blacklisted = false });
            food.Add(new Food { name = "Wołowina", categories = Enums.Categories.Meats, blacklisted = false });
            food.Add(new Food { name = "Kebab", categories = Enums.Categories.Meals, blacklisted = false });
            food.Add(new Food { name = "Marchewka", categories = Enums.Categories.Vegetables, blacklisted = false });

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
