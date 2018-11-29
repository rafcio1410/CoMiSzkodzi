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

        public MogePageModel ()
		{
            var canList = DatabaseConnection.Connection.QueryAsync<Food>("SELECT * FROM Food WHERE blacklisted = 2");
            CanList = canList.Result;
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