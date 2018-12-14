using CoMiSzkodzi.Databases;
using CoMiSzkodzi.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CoMiSzkodzi.Helpers
{
    public class FoodGrouping
    {
        public ObservableCollection<FoodGroupingList> CreateGroupsFromData(List<Food> foods)
        {
            ObservableCollection<FoodGroupingList> groups = new ObservableCollection<FoodGroupingList>();
            List<Categories> headerlist = new List<Categories>();
            List<Food> userList = new List<Food>();
            List<Food> veggieList = new List<Food>();
            List<Food> fruitList = new List<Food>();
            List<Food> drinksList = new List<Food>();
            List<Food> meatsList = new List<Food>();
            List<Food> diaryList = new List<Food>();
            List<Food> snacksList = new List<Food>();
            List<Food> spicesList = new List<Food>();
            List<Food> mealsList = new List<Food>();
            List<Food> otherList = new List<Food>();
            userList = foods.FindAll(c => c.categories.Equals(Categories.User));
            veggieList = foods.FindAll(c => c.categories.Equals(Categories.Vegetables));
            fruitList = foods.FindAll(c => c.categories.Equals(Categories.Fruits));
            drinksList = foods.FindAll(c => c.categories.Equals(Categories.Drinks));
            meatsList = foods.FindAll(c => c.categories.Equals(Categories.Meats));
            diaryList = foods.FindAll(c => c.categories.Equals(Categories.Diary));
            snacksList = foods.FindAll(c => c.categories.Equals(Categories.Snacks));
            spicesList = foods.FindAll(c => c.categories.Equals(Categories.Spices));
            mealsList = foods.FindAll(c => c.categories.Equals(Categories.Meals));
            otherList = foods.FindAll(c => c.categories.Equals(Categories.Others));

            if (diaryList.Count > 0)
            {
                groups.Add(new FoodGroupingList( "Nabiał", diaryList ));
            }
            if (userList.Count > 0)
            {
                groups.Add(new FoodGroupingList ("Użytkownika", userList ));
            }
            if (veggieList.Count > 0)
            {
                groups.Add(new FoodGroupingList ( "Warzywa", veggieList ));
            }
            if (fruitList.Count > 0)
            {
                groups.Add(new FoodGroupingList ("Owoce", fruitList ));
            }
            if (drinksList.Count > 0)
            {
                groups.Add(new FoodGroupingList ("Napoje", drinksList ));
            }
            if (meatsList.Count > 0)
            {
                groups.Add(new FoodGroupingList ( "Mięsa", meatsList ));
            }
            if (snacksList.Count > 0)
            {
                groups.Add(new FoodGroupingList ("Przekąski", snacksList ));
            }
            if (spicesList.Count > 0)
            {
                groups.Add(new FoodGroupingList ("Przyprawy", spicesList ));
            }
            if (mealsList.Count > 0)
            {
                groups.Add(new FoodGroupingList ("Dania", mealsList ));
            }
            if (otherList.Count > 0)
            {
                groups.Add(new FoodGroupingList ( "Inne", otherList ));
            }
            return groups;


        }
    }
}
