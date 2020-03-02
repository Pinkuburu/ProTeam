using System;
using System.Collections.Generic;

namespace MyStatz.Models
{
    public class Player
    {    
        public int LastUpdateDateTime { get; set; }
        public SteamAccount SteamAccount { get; set; }
        public int MatchCount { get; set; }
        public ActivityEnum Activity { get; set; }
        public int Imp { get; set; }
    } 
}