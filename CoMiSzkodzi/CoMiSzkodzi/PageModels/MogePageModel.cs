using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Windows.Input;
using CoMiSzkodzi.Databases;

namespace CoMiSzkodzi
{
	public class MogePageModel : FreshBasePageModel
	{
        List<Food> _canlist;
        public List<Food> CanList
        {
            get
            {
                return _canlist;
            }
            set
            {
                _canlist = value;
                RaisePropertyChanged("CanList");
            }
        }

        List<Food> _canfruitslist;
        public List<Food> CanFruitsList
        {
            get
            {
                return _canfruitslist;
            }
            set
            {
                _canfruitslist = value;
                RaisePropertyChanged("CanFruitsList");
            }
        }

        public MogePageModel ()
		{
            var canList = DatabaseConnection.Connection.QueryAsync<Food>("SELECT * FROM Food WHERE blacklisted = 0 AND categories = 1 ORDER BY name" );
            CanList = canList.Result;

            var canfruitslist = DatabaseConnection.Connection.QueryAsync<Food>("SELECT * FROM Food WHERE blacklisted = 0 AND categories = 2 ORDER BY name");
            CanFruitsList = canfruitslist.Result;

            CanList.AddRange(CanFruitsList); // łączymy dwie listy

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