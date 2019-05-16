using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
   public static class GloblaConfig
    {
        // only methods inside the GlobalConfig class can set the value, But everyone can read the value.
        // List will hold anything that implement the IDataconnection interface.
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
        

        public static void InitializeConnections(bool database, bool textfiles)
        {
            if(database)
            {
                //TODO - setup the sql connector properly.
                SQLConnector sql = new SQLConnector(); // created an instance of SQLconnector class
                Connections.Add(sql); // Adding the connection instance to Connections List.
            }
            if(textfiles)
            {
                //TODO - setup the TextFile connection properly.
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
