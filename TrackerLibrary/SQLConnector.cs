using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class SQLConnector : IDataConnection
    {   
        //TODO - Make the createPrize model actually save in the DB.
        /// <summary>
        /// Save the new prize to the database.
        /// </summary>
        /// <param name="model">The prize information.</param>
        /// <returns>The prize infromation, including unique identifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
