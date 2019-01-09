using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SegmentedControl.FormsPlugin.Android;

namespace CoMiSzkodzi.Droid
{
    [Activity(Label = "CoMiSzkodzi", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI2NDRAMzEzNjJlMzQyZTMwTzN3K0JSbVBlVEthZHN6SElRdmNNVEFJREIzU2x0T0ZDamJ2Z05ZQWhxbz0=");
            SegmentedControlRenderer.Init();
            LoadApplication(new App());
        }
    }
}