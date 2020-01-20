using System;
using System.Collections.Generic;

namespace MyStatz.Models
{
    public class Player
    {       
        //public int RankVariance { get; set; }
        public int LastUpdateDateTime { get; set; }
        public SteamAccount SteamAccount { get; set; }
        public int MatchCount { get; set; }
        public int Activity { get; set; }
    } 
}