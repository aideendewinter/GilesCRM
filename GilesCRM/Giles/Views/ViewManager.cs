using GilesCRM.Giles.Application;
using System.IO;
using System.Runtime.Serialization.Json;
using System;

namespace GilesCRM.Giles.Views
{
    class ViewManager
    {
        BaseView currentView;
        public ViewManager(SettingsManager settings) {
            string defaultViewFilename = settings.getDefaultView();
            // TO-DO: Error handling.
            FileStream stream = new FileStream(defaultViewFilename, FileMode.Open);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BaseView));
            currentView = (BaseView)ser.ReadObject(stream);
            UpdateView();
        }

        private void UpdateView()
        {
           // TO-DO: attach current view to main window xaml.
        }
    }
}
