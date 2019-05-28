using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelper;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {

        private const string PrizeFile = "PrizeModels.csv";

        //TODO - Make CreatePrize Model actually connect to a text File.
        public PrizeModel CreatePrize(PrizeModel model)
        {   
            //Load the text file
            //Convert the text to List<Prizes>
            List<PrizeModel> prizes = PrizeFile.FullFilePath().LoadFile().ConvertToPrizeModel();

            //Find the Max ID
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }    
                
            model.Id = currentId;

            //Add the new record with new ID(Max+1)
            prizes.Add(model);

            //Convert the prize to List<string>
            //Save the string to the text file
            prizes.SaveToPrizeFile(PrizeFile);

            return model;
        }
    }
}
