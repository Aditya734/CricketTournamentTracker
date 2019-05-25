using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
   public static class GloblaConfig
    {
        // only methods inside the GlobalConfig class can set the value, But everyone can read the value.
        // List will hold anything that implement the IDataconnection interface.
        public static IDataConnection Connection { get; private set; }
        

        public static void InitializeConnections(DatabaseType db)
        {
            if(db == DatabaseType.Sql)
            {
                //TODO - setup the sql connector properly.
                SQLConnector sql = new SQLConnector(); // created an instance of SQLconnector class
                Connection = sql; // Adding the connection instance to Connections List.
            }
            else if(db == DatabaseType.TextFile)
            {
                //TODO - setup the TextFile connection properly.
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString; //add reference Configuration manager.
        }
    }
}
