using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

//@PlaceNumber int,
//@PlaceName nvarchar(100),
//@PrizeAmount decimal (18,0),
//@PrizePercentage decimal (18,0),

namespace TrackerLibrary.DataAccess
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
            //IDbConnection is an interface inheriting from Idisposable to dispose the connection.
            //using will distroy the connection once it comes to end of {}. Converted to Finally block at complile time.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GloblaConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName",model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }
    }
}
