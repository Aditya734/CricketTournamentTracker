using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represent one team in the Matchup.
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Represent the Score for this perticular team.
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Represent the matchup that this team came from as the winner.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}
