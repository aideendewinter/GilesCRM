using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GilesCRM.Giles.Views
{
    [DataContract]
    class DataView : BaseView
    {
        [DataMember]
        protected Dictionary<string, string> dataBindings;
        
        public override FrameworkElement GetUI(SettingsManager settings) {
            if (myUI == null) {
                base(settings);
                // Bind data
            }
            return myUI;
        }
    }
}
