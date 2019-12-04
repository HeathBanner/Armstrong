using System;
using System.Collections.Generic;
using ArmstrongPoker.Models;

namespace ArmstrongPoker.Engine
{
    class Finalize : WinnerCheck
    {
        public static string WhoWon(List<WinnerModels> Royal,
            List<WinnerModels> ToK, List<WinnerModels> Straight,
            List<WinnerModels> Flush, List<WinnerModels> Pair,
            HighestCard highestcard, Royalty royalty)
        {
            string result;

            if (Royal.Count > 0)
            {
                Winner(ref Royal, ref royalty, ref highestcard, "Royal Flush", out result);
                return result;
            }

            if (ToK.Count > 0)
            {
                Winner(ref ToK, ref royalty, ref highestcard, "Three of a Kind", out result);
                return result;
            }

            if (Straight.Count > 0)
            {
                Winner(ref Straight, ref royalty, ref highestcard, "Straight", out result);
                return result;
            }

            if (Flush.Count > 0)
            {
                Winner(ref Flush, ref royalty, ref highestcard, "Flush", out result);
                return result;
            }

            if (Pair.Count > 0)
            {
                Winner(ref Pair, ref royalty, ref highestcard, "Pair", out result);
                return result;
            }

            return $"Player: {highestcard.playerId} has won with the highest card {highestcard.Total}";
        }
    }
}
