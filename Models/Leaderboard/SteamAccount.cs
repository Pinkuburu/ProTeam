using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProTeam.Models
{
    public class SteamAccount
    {
        public ProSteamAccount ProSteamAccount { get; set; }
        public int SeasonLeaderboardRank { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }

    }
}
