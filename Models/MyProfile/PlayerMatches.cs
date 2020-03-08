using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProTeam.Models
{
    public class PlayerMatches
    {                      
        public int DurationSeconds { get; set; }        
        public int EndDateTime { get; set; }        
        public int GameMode { get; set; }
        public List<Players> Players { get; set; }


    }
}
