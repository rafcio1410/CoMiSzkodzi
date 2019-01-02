using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using CoMiSzkodzi.Helpers;
using CoMiSzkodzi.PageModels;

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
                    WeekDayParameter weekDay = new WeekDayParameter();
                    weekDay.DayOfTheWeek = Enums.WeekDays.Monday;
                    await CoreMethods.PushPageModel<WeekDayPageModel>(weekDay);
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
                    WeekDayParameter weekDay = new WeekDayParameter();
                    weekDay.DayOfTheWeek = Enums.WeekDays.Tuesday;
                    await CoreMethods.PushPageModel<WeekDayPageModel>(weekDay);
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
                    WeekDayParameter weekDay = new WeekDayParameter();
                    weekDay.DayOfTheWeek = Enums.WeekDays.Wendnsday;
                    await CoreMethods.PushPageModel<WeekDayPageModel>(weekDay);
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
                    WeekDayParameter weekDay = new WeekDayParameter();
                    weekDay.DayOfTheWeek = Enums.WeekDays.Thursday;
                    await CoreMethods.PushPageModel<WeekDayPageModel>(weekDay);
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
                    WeekDayParameter weekDay = new WeekDayParameter();
                    weekDay.DayOfTheWeek = Enums.WeekDays.Friday;
                    await CoreMethods.PushPageModel<WeekDayPageModel>(weekDay);
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
                    WeekDayParameter weekDay = new WeekDayParameter();
                    weekDay.DayOfTheWeek = Enums.WeekDays.Saturday;
                    await CoreMethods.PushPageModel<WeekDayPageModel>(weekDay);
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
                    WeekDayParameter weekDay = new WeekDayParameter();
                    weekDay.DayOfTheWeek = Enums.WeekDays.Sunday;
                    await CoreMethods.PushPageModel<WeekDayPageModel>(weekDay);
                    tcs.SetResult(true);
                });
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


        public PodsumujPosilkiPageModel ()
		{
            Title = "Podsumuj Posiłki";
            NavBarBackgroundColor = Color.Goldenrod;
        }
	}
}