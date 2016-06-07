using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows;
using System.IO;

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
        
        public FrameworkElement GetUI() {
            FrameworkElement element;
            FileStream s = new FileStream(xamlFilename, FileMode.Open);
            element = (FrameworkElement)XamlReader.Load(s);
            s.Close();
            if (tableName != "") {
                // TO-DO: Bind data.
            }
            
            foreach(KeyValuePair<string, BaseView> child in children) {
                ((ContentControl)element.FindName(child.Key)).Content = child.Value.GetUI();
            }
            return element;
        }
    }
}
