﻿using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Windows.Input;
using CoMiSzkodzi.Databases;
using CoMiSzkodzi.Helpers;
using System.Collections.ObjectModel;

namespace CoMiSzkodzi
{
	public class MogePageModel : FreshBasePageModel
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

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            var foodList = DatabaseConnection.Connection.QueryAsync<Food>("SELECT * FROM Food WHERE blacklisted = 0 ORDER BY name");
            var listToSort = foodList.Result;
            FoodGrouping foodGrouping = new FoodGrouping();

            FoodList = foodGrouping.CreateGroupsFromData(listToSort);
        }

            public MogePageModel ()
		{
            NavBarBackgroundColor = Color.Green;
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