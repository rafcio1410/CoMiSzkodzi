using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoMiSzkodzi.Helpers
{
    public class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        private const string HasRunBeforeKey = "HasRunBeforeKey";
        public static bool HasRunBeforeDefault = false;
        public static bool HasRunBefore
       
        {
            get
            {
                return AppSettings.GetValueOrDefault(HasRunBeforeKey, HasRunBeforeDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(HasRunBeforeKey, value);
            }
        }
    }
}
