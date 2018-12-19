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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI2NDRAMzEzNjJlMzQyZTMwTzN3K0JSbVBlVEthZHN6SElRdmNNVEFJREIzU2x0T0ZDamJ2Z05ZQWhxbz0=");
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
            food.Add(new Food { name = "Marchewka", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.ToCheck }); // Odtąd WARZYWA
            food.Add(new Food { name = "Cebula", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.ToCheck });
            food.Add(new Food { name = "Por", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.ToCheck });
            food.Add(new Food { name = "Szczypiorek", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.ToCheck });
            food.Add(new Food { name = "Koperek", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.ToCheck });
            food.Add(new Food { name = "Buraki", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.ToCheck });
            food.Add(new Food { name = "Ziemniaki", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.ToCheck });
            food.Add(new Food { name = "Groszek", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.ToCheck });
            food.Add(new Food { name = "Fasola", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.ToCheck });
            food.Add(new Food { name = "Bób", categories = Enums.Categories.Vegetables, blacklisted = Enums.BlackListed.ToCheck });
            food.Add(new Food { name = "Banan", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.ToCheck }); //Odtąd OWOCE
            food.Add(new Food { name = "Jabłko surowe", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Jabłko gotowane", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Ananas", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Truskawki", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Maliny", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Porzeczki", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Winogrona", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Pomarańcze", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Śliwki", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Mandarynki", categories = Enums.Categories.Fruits, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Kurczak", categories = Enums.Categories.Meats, blacklisted = Enums.BlackListed.Can }); // Reszte posegregowac
            food.Add(new Food { name = "Mleko", categories = Enums.Categories.Diary, blacklisted = Enums.BlackListed.CanNot });
            food.Add(new Food { name = "Sól", categories = Enums.Categories.Spices, blacklisted = Enums.BlackListed.Check });
            food.Add(new Food { name = "Miód", categories = Enums.Categories.Others, blacklisted = Enums.BlackListed.Can });
            food.Add(new Food { name = "Kopytka", categories = Enums.Categories.Meals, blacklisted = Enums.BlackListed.Check });
            food.Add(new Food { name = "Sok Pomarańczowy", categories = Enums.Categories.Drinks, blacklisted = Enums.BlackListed.CanNot });
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
