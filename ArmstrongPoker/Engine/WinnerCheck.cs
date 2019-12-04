using System;
using System.Collections.Generic;
using ArmstrongPoker.Models;

namespace ArmstrongPoker.Engine
{
    class WinnerCheck : Winner
    {

        public static void Winner(ref List<WinnerModels> list, ref Royalty royalty,
            ref HighestCard highestCard, string type, out string result)
        {
            string winners = "";
            string highestRoyal = royalty.HighestRoyal;

            foreach (WinnerModels player in list)
            {
                winners = $"{winners} {player.playerId}";
            }

            if (list.Count > 1 && highestRoyal == "Commoner")
            {
                result = $"It's a tie! Players: {winners} had a {type}! Player {highestCard.playerId} won with the highest hand {highestCard.Total}";
                return;
            }
            if (list.Count > 1 && highestRoyal != "Commoner")
            {
                result = $"It's a tie! Players: {winners} had a {type}! Player {royalty.playerId} won with the highest Royal {RoyalInterpreter(royalty.HighestRoyal)}";
                return;
            }

            result = $"Player: {winners} won with a {type}!";
        }

        static string RoyalInterpreter(string royal)
        {
            switch (royal)
            {
                case "A":
                    return "Ace";
                case "K":
                    return "King";
                case "Q":
                    return "Queen";
                default:
                    return "Jack";
            }
        }
    }
}
