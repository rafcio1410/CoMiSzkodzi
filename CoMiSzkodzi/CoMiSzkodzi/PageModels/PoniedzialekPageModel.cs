using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using CoMiSzkodzi.Databases;

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
	}
}