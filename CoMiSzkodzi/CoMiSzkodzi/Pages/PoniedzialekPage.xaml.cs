﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoMiSzkodzi
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PoniedzialekPage : ContentPage
	{
		public PoniedzialekPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void SegmentValueChanged(object sender, Plugin.Segmented.Event.SegmentSelectEventArgs e)
        {
            var test = "test";
        }
    }
}