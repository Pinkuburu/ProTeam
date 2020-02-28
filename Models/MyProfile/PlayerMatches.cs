using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStatz.Models
{
    public class PlayerMatches
    {
        public long Id { get; set; }
        public bool DidRadiantWin { get; set; }
        public LobbyTypeEnum LobbyType { get; set; }
        public int DurationSeconds { get; set; }
        public int StartDateTime { get; set; }
        public int EndDateTime { get; set; }
        public int AvgImp { get; set; }
        public int GameMode { get; set; }

        public List<Players> Players { get; set; }


    }
}
