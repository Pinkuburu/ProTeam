using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStatz.Models
{
    public enum LobbyTypeEnum
    {
       [StringValue("Invalid")]
       Invalid = -1,
       [StringValue("Normal")]
       Public_matchmaking = 0,
       [StringValue("Practice")]
       Practice = 1, 
       [StringValue("Tournament")]
       Tournament = 2,
       [StringValue("Tutorial")]
       Tutorial = 3 ,
       [StringValue("Bot")]
       Coop_with_bots = 4,
       [StringValue("Team")]
       Team_match = 5,
       [StringValue("Solo")]
       Solo_queue = 6,
       [StringValue("Ranked")]
       Ranked = 7,
       [StringValue("Solo Mid")]
       Solo_mid = 8 
    }
}
