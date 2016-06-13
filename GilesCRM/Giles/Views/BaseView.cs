using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows;
using System.IO;
using GilesCRM.Giles.App;

namespace GilesCRM.Giles.Views
{
    [DataContract]
    [KnownType(typeof(SearchView))]
    [KnownType(typeof(DataView))]
    class BaseView {
        [DataMember]
        protected string tableName;
        [DataMember]
        protected Dictionary<string, BaseView> children;
        [DataMember]
        protected string xamlFilename;
        
        protected FrameworkElement myUI;
        
        public virtual FrameworkElement GetUI(SettingsManager settings) {
            if (myUI == null) {
                FileStream s = new FileStream(settings.getViewsFolder() + xamlFilename, FileMode.Open);
                myUI = (FrameworkElement)XamlReader.Load(s);
                s.Close();
                if (children != null)
                {
                    foreach (KeyValuePair<string, BaseView> child in children)
                    {
                        ((ContentControl)myUI.FindName(child.Key)).Content = child.Value.GetUI(settings);
                    }
                }
            }
            return myUI;
        }
    }
}
