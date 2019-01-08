using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CoMiSzkodzi.Databases;
using CoMiSzkodzi.Enums;
using CoMiSzkodzi.Helpers;
using FreshMvvm;
using Xamarin.Forms;

namespace CoMiSzkodzi.PageModels
{
    public class WeekDayPageModel : FreshBasePageModel
    {
        WeekDayParameter weekDay 
        {
            get;
            set;
        }
        public override void Init(object initData)
        {
            //Since all of the week day pages look exactly the same. There is no point having 7 seperate
            //classes containing exactly the same code. Instead we can just use the same page and pass
            //page parameter and based on that load correct database, set title, background color etc.
            base.Init(initData);
            weekDay = (WeekDayParameter)initData;
            switch (weekDay.DayOfTheWeek)
            {
                case WeekDays.Monday:
                    InitilizeMonday();
                    return;
                case WeekDays.Tuesday:
                    InitilizeTuesday();
                    return;
                case WeekDays.Wendnsday:
                    InitilizeWendnsday();
                    return;
                case WeekDays.Thursday:
                    InitilizeThursday();
                    return;
                case WeekDays.Friday:
                    InitilizeFriday();
                    return;
                case WeekDays.Saturday:
                    InitilizeSaturday();
                    return;
                case WeekDays.Sunday:
                    InitilizeSunday();
                    return;
                default:
                    return;
            }
        }
        public void InitilizeMonday()
        {
            Title = "Poniedzialek";
            NavBarBackgroundColor = Color.Goldenrod;
        }
        public void InitilizeTuesday()
        {
            Title = "Wtorek";
            NavBarBackgroundColor = Color.Goldenrod;
        }
        public void InitilizeWendnsday()
        {
            Title = "Sroda";
            NavBarBackgroundColor = Color.Goldenrod;
        }
        public void InitilizeThursday()
        {
            Title = "Czwartek";
            NavBarBackgroundColor = Color.Goldenrod;
        }
        public void InitilizeFriday()
        {
            Title = "Piatek";
            NavBarBackgroundColor = Color.Goldenrod;
        }
        public void InitilizeSaturday()
        {
            Title = "Sobota";
            NavBarBackgroundColor = Color.Goldenrod;
        }
        public void InitilizeSunday()
        {
            Title = "Niedziela";
            NavBarBackgroundColor = Color.Goldenrod;
        }
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
        public ICommand AddNewFoodCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<AddNewFoodPageModel>();
                    tcs.SetResult(true);
                });
            }
        }
        public ICommand SegmentValueChanged
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    tcs.SetResult(true);
                });
            }
        }
        public ICommand RemoveProductCommand
        {
            get
            {
                return new FreshAwaitCommand(async (product, tcs) =>
                {
                    await RemovePreductFromDatabase(product);
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
                if (_searchTerm != value)
                {
                    _searchTerm = value;
                    RaisePropertyChanged("SearchTerm");
                    FilterItems();
                }
            }
        }
        public Task RemovePreductFromDatabase(object Item)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);
            return tcs.Task;
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
                foreach (var item in foodList)
                {
                    if (item.Where(c => c.name.ToLower().Contains(cleanSearchTerm)).Count() > 0)
                    {
                        foreach (var food in item)
                        {
                            if (food.name.ToLower().Contains(cleanSearchTerm))
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
        public Task UpdateDatabase()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            List<Food> listofFood = new List<Food>();
            foreach (var item in FoodList)
            {
                listofFood.AddRange(item);
            }
            var result = DatabaseConnection.Connection.UpdateAllAsync(listofFood);
            result.Wait();
            if (result.IsCompleted)
            {
                tcs.SetResult(true);
                return tcs.Task;
            }
            tcs.SetResult(false);
            return tcs.Task;
        }
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            RefreshList();

        }
        public void RefreshList()
        {
            var foodList = DatabaseConnection.Connection.QueryAsync<Food>("SELECT * FROM Food");
            var listToSort = foodList.Result;
            FoodGrouping foodGrouping = new FoodGrouping();

            FoodList = foodGrouping.CreateGroupsFromData(listToSort);
            oldFoodList = FoodList;
        }

        public ICommand NavigateHomeCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    var result = await CoreMethods.DisplayAlert("Uwaga", "Czy zapisac zmiany?", "Tak", "Nie");
                    if (result)
                    {
                        await UpdateDatabase();
                        await CoreMethods.PopToRoot(false);
                        tcs.SetResult(true);
                    }
                    else
                    {
                        await CoreMethods.PopToRoot(false);
                        tcs.SetResult(true);
                    }

                });
            }
        }

        public ICommand NavigateBackCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    var result = await CoreMethods.DisplayAlert("Uwaga", "Czy chcialbys zapisac zmiany?", "Tak", "Nie");
                    if (result)
                    {
                        await UpdateDatabase();
                        await CoreMethods.PopPageModel();
                        tcs.SetResult(true);
                    }
                    else
                    {
                        await CoreMethods.PopPageModel();
                        tcs.SetResult(true);
                    }
                });
            }
        }

        private Color _navBarBackgroundColor;
        public Color NavBarBackgroundColor
        {
            get
            {
                return _navBarBackgroundColor;
            }
            set
            {
                _navBarBackgroundColor = value;
                RaisePropertyChanged("NavBarBackgroundColor");
            }
        }

    }
}

