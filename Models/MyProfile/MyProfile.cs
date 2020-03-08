using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProTeam.Models
{
    public class MyProfile
    {
        public PlayerInfo PlayerInfo { get; set; }
        public List<PlayerMatches> PlayerMatches { get; set; }
    }
}
