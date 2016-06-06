using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
