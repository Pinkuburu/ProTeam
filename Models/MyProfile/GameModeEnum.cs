using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProTeam.Models
{
    public class GameMode
    {
        public static IDictionary<int, string> GameModeNames { get; set; } = new Dictionary<int, string>()
        {
            {0, "Unknown"},
            {1, "All Pick"},
            {2, "Captains Mode"},
            {3, "Random Draft"},
            {4, "Single Draft"},
            {5, "All Random"},
            {6, "Intro"},
            {7, "The Diretide"},
            {8, "Reverse Captains Mode"},
            {9, "Greeviling"},
            {10, "Tutorial"},
            {11, "Mid Only"},
            {12, "Least Played"},
            {13, "New Player Pool"},
            {14, "Compendium Matchmaking"},
            {15, "Custom"},
            {16, "Captains Draft"},
            {17, "Balanced Draft"},
            {18, "Ability Draft"},
            {19, "Event"},
            {20, "All Random Death Match"},
            {21, "Solo Mid"},
            {22, "Rank" },
            {23, "Turbo" }
        };
    }   
}
