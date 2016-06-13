using GilesCRM.Giles.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GilesCRM.Giles.Views
{
    [DataContract]
    class DataView : BaseView
    {
        [DataMember]
        protected Dictionary<string, string> dataBindings;
        
        public override FrameworkElement GetUI(SettingsManager settings) {
            if (myUI == null) {
                base.GetUI(settings);
                // Bind data
            }
            return myUI;
        }
    }
}
