using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Windows.Input;

namespace CoMiSzkodzi
{
	public class PodsumujPosilkiPageModel : FreshBasePageModel
	{
        public ICommand MondayCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<PoniedzialekPageModel>();
                    tcs.SetResult(true);
                });
            }
        }

        public ICommand TuesdayCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<WtorekPageModel>();
                    tcs.SetResult(true);
                });
            }
        }

        public ICommand WednesdayCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<SrodaPageModel>();
                    tcs.SetResult(true);
                });
            }
        }

        public ICommand ThursdayCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<CzwartekPageModel>();
                    tcs.SetResult(true);
                });
            }
        }

        public ICommand FridayCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<PiatekPageModel>();
                    tcs.SetResult(true);
                });
            }
        }

        public ICommand SaturdayCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<SobotaPageModel>();
                    tcs.SetResult(true);
                });
            }
        }

        public ICommand SundayCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<NiedzielaPageModel>();
                    tcs.SetResult(true);
                });
            }
        }

        public PodsumujPosilkiPageModel ()
		{
			
		}
	}
}