using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Windows.Input;

namespace CoMiSzkodzi
{
	public class MainPageModel : FreshBasePageModel
	{
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

        public ICommand InformationsCommand
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


        public MainPageModel ()
		{
            

        }
	}
}