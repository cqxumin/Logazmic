namespace Logazmic.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;

    using Logazmic.Core.Reciever;

    public class LogazmicSettings : JsonSettingsBase
    {
        #region Singleton

        private static readonly Lazy<LogazmicSettings> instance = new Lazy<LogazmicSettings>(() => Load<LogazmicSettings>(path));

        public static LogazmicSettings Instance { get { return instance.Value; } }

        #endregion

        private static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Logazmic\settings.json");

        public ObservableCollection<IReceiver> Receivers { get; set; }

        [DefaultValue(12)]
        public int GridFontSize { get; set; }

        [DefaultValue(18)]
        public int DescriptionFontSize { get; set; }

        [DefaultValue(false)]
        public bool UseDarkTheme { get; set; }

        protected override void SetDefaults()
        {
            base.SetDefaults();
            Receivers = new ObservableCollection<IReceiver>();
        }

        protected override void Save()
        {
            Save(path);
        }
    }
}