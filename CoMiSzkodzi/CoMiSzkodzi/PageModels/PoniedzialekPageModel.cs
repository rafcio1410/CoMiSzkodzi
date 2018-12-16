using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using CoMiSzkodzi.Databases;
using System.Windows.Input;
using CoMiSzkodzi.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CoMiSzkodzi
{
    public class PoniedzialekPageModel : FreshBasePageModel
	{
        ObservableCollection<FoodGroupingList> _foodlist;
        public ObservableCollection<FoodGroupingList> FoodList
        {
            get
            {
                return _foodlist;
            }
            set
            {
                _foodlist = value;
                RaisePropertyChanged("FoodList");
            }
        }
        ObservableCollection<FoodGroupingList> oldFoodList;
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }
        private ICommand _filterProducts;
        public ICommand FilterProducts
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await FilterItems();
                    tcs.SetResult(true);
                });
            }
        }
        private string _searchTerm;
        public string SearchTerm
        {
            get
            {
                return _searchTerm;
            }
            set
            {
                if(_searchTerm != value)
                {
                    _searchTerm = value;
                    RaisePropertyChanged("SearchTerm");
                    FilterItems();
                }
            }
        }
        public void OnSearchTermTextChanged()
        {
            var foodList = oldFoodList.ElementAt(1);
            var filteredList = oldFoodList.ElementAt(1).Where(c => c.name.Contains(SearchTerm));
            FoodGrouping foodGrouping = new FoodGrouping();
            FoodList = foodGrouping.CreateGroupsFromData(filteredList.ToList());
        }

        public Task FilterItems()
        {
            var cleanSearchTerm = SearchTerm.ToLower().Trim();
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            if (String.IsNullOrWhiteSpace(cleanSearchTerm))
            {
                FoodList = oldFoodList;
            }
            else
            {
                List<Food> filteredFood = new List<Food>();
                var foodList = oldFoodList;
                foreach(var item in foodList)
                {
                    if(item.Where(c => c.name.ToLower().Contains(cleanSearchTerm)).Count() > 0)
                    {
                        foreach(var food in item)
                        {
                            if(food.name.ToLower().Contains(cleanSearchTerm))
                            {
                                filteredFood.Add(food);
                            }
                        }
                    }
                }
                FoodGrouping foodGrouping = new FoodGrouping();
                FoodList = foodGrouping.CreateGroupsFromData(filteredFood);
            }
            tcs.SetResult(true);
            return tcs.Task;
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            var foodList = DatabaseConnection.Connection.QueryAsync<Food>("SELECT * FROM Food");
            var listToSort = foodList.Result;
            FoodGrouping foodGrouping = new FoodGrouping();

            FoodList = foodGrouping.CreateGroupsFromData(listToSort);
            oldFoodList = FoodList;
        }
        public PoniedzialekPageModel ()
		{
            Title = "Poniedziałek";
        }

        public ICommand NavigateHomeCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PopToRoot(false);
                    tcs.SetResult(true);
                });
            }
        }

        public ICommand NavigateBackCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PopPageModel();
                    tcs.SetResult(true);
                });
            }
        }
    }
}