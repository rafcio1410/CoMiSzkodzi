using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Plugin.Segmented.Control.iOS;
using UIKit;

namespace CoMiSzkodzi.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI2NDZAMzEzNjJlMzMyZTMwb1pKcEVYNGZhVWw2d2JDVTNNNHVtMzMyMnJRRUZyM2l6OE9PbThrY2E5cz0=");
            SegmentedControlRenderer.Initialize();
            Syncfusion.XForms.iOS.Buttons.SfSegmentedControlRenderer.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
