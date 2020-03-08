using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProTeam.Models
{
    public class GlobalLeaderBoard
    {
        public LeaderBoard AmericaLeaderBoard{ get; set; }
        public LeaderBoard SEAsiaLeaderBoard { get; set; }
        public LeaderBoard EuropeLeaderBoard { get; set; }
        public LeaderBoard ChinaLeaderBoard { get; set; }
        public int CurrentPage { get; set; }

    }
}
