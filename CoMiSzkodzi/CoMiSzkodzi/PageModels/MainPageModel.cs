using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Windows.Input;
using CoMiSzkodzi.PageModels;

namespace CoMiSzkodzi
{
	public class MainPageModel : FreshBasePageModel
	{
        public ICommand WhatYouEatCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<DzisiejszePosilkiPageModel>();
                    tcs.SetResult(true);
                });
            }
        }

        public ICommand WeekCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<PodsumujPosilkiPageModel>();
                    tcs.SetResult(true);
                });
            }
        }

        public ICommand CheckCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<MogeNieMogePageModel>();
                    tcs.SetResult(true);
                });
            }
        }

        public ICommand InformationsCommand
        {
            get
            {
                return new FreshAwaitCommand(async (contact, tcs) =>
                {
                    await CoreMethods.PushPageModel<InformacjePageModel>();
                    tcs.SetResult(true);
                });
            }
        }


        public MainPageModel ()
		{
            

        }
	}
}