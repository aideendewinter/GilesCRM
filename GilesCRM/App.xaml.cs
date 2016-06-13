using GilesCRM.Giles.App;
using GilesCRM.Giles.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GilesCRM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() {
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create the startup window
            MainWindow wnd = new MainWindow();
            wnd.Show();

            string settingsFolder = "Ravenhearte Design/Giles CRM";
            // Create dummy settings object for testing.
            ConnectionData connData = new ConnectionData();

            SettingsManager settings = new SettingsManager(""//Environment.SpecialFolder.ApplicationData
                + settingsFolder + "/Views/", "default.json", connData);

            ViewManager viewManager = new ViewManager(settings);
        }
    }
}
