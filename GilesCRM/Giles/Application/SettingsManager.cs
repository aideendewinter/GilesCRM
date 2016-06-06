using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GilesCRM.Giles.Application
{
    class SettingsManager {
        SettingsData mySettings;
        public SettingsManager(string pathName) {
            // TO-DO: Error handling
            FileStream stream = new FileStream(pathName, FileMode.OpenOrCreate);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(SettingsData));
            mySettings = (SettingsData)ser.ReadObject(stream);
        }
        
        public string getDefaultView() {
          return mySettings.viewsFolderPathname + mySettings.defaultViewFilename;
        }
        
        public ConnectionData getDefaultConnection() {
          return mySettings.defaultConnection;
        }
    }
    [DataContract}
    public class ConnectionData {
      [DataMember]
      string databaseName;
      [DataMember]
      string userName;
      [DataMember]
      string password;
    }
    [DataContract]
    class SettingsData {
      [DataMember]
      ConnectionData defaultConnection;
      [DataMember]
      string viewsFolderPathname;
      [DataMember]
      string defaultViewFilename;
    }
}
