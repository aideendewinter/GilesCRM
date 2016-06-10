using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace GilesCRM.Giles.App
{
  class ConnectionManager {
    
    protected NpgsqlConnection defaultConnection;
    
    public ConnectionManager(SettingsManager settings) {
      ConnectionData connData = settings.getDefaultConnection();
      try {
        // PostgeSQL-style connection string
        string connstring = String.Format("Server={0};Port={1};" + 
          "User Id={2};Password={3};Database={4};",
          "localhost", "", connData.userName, 
          connData.password, connData.databaseName);

        // Making connection with Npgsql provider
        defaultConnection = new NpgsqlConnection(connstring);
        defaultConnection.Open();
      } catch (Exception msg) {
        // something went wrong, and you wanna know why
        MessageBox.Show(msg.ToString());
        throw;
      }
    }
    
    public NpgsqlConnection getDefaultConnection() {
      return defaultConnection;
    }
    
    ~ConnectionManager() {
      defaultConnection.close();
    }
  }
}
