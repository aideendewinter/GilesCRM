using GilesCRM.Giles.App;
using System.IO;
using System.Runtime.Serialization.Json;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GilesCRM.Giles.Views
{
    class ViewManager
    {
        BaseView currentView;
        public ViewManager(SettingsManager settings, ConnectionManager connections) {
            string defaultViewFilename = settings.getDefaultView();
            // TO-DO: Error handling.
            FileStream stream = new FileStream(defaultViewFilename, FileMode.Open);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BaseView));
            currentView = ser.ReadObject(stream) as BaseView;
            UpdateView(settings, connections.getDefaultConnection());
        }
        
        private void UpdateView(SettingsManager settings, NpgsqlConnection connection)
        {
            ((ContentControl)Application.Current.MainWindow.FindName("ViewContent")).Content
                = currentView.GetUI(settings, connection);
        }
    }
}
