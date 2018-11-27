using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using CoMiSzkodzi.Databases;
using System.Windows.Input;

namespace CoMiSzkodzi
{

	public class PoniedzialekPageModel : FreshBasePageModel
	{
        List<Food> _foodlist;
        public List<Food> FoodList
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


        public PoniedzialekPageModel ()
		{
            var foodList = DatabaseConnection.Connection.QueryAsync<Food>("SELECT * FROM Food");
            FoodList = foodList.Result;
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