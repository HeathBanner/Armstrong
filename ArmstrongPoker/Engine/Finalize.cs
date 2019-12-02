using System;
using System.Collections.Generic;
using ArmstrongPoker.Models;

namespace ArmstrongPoker.Engine
{
    public class Finalize
    {
        public static string WhoWon(List<WinnerModels> Royal, List<WinnerModels> ToK, List<WinnerModels> Straight, List<WinnerModels> Flush, List<Pair> Pair, HighestCard highestcard)
        {
            string winners = "";

            if (Royal.Count > 0)
            {
                foreach (WinnerModels player in Royal)
                {
                    winners = $"{winners} {player.playerId}";
                }
                if (Royal.Count > 1) { return $"It's a tie! Players: {winners} won with a Royal Flush!"; }
                return $"Player: {winners} won with a Royal Flush!";
            }

            if (ToK.Count > 0)
            {
                foreach (WinnerModels player in ToK) {
                    winners = $"{winners} {player.playerId}";
                }

                if (ToK.Count > 1) { return $"It's a tie! Players: {winners} won with a Three of a Kind!"; }

                return $"Player: {winners} won with a Three of a Kind!";
            }

            if (Straight.Count > 0)
            {
                foreach (WinnerModels player in Straight)
                {
                    winners = $"{winners} {player.playerId}";
                }
                if (Straight.Count > 1) { return $"It's a tie! Players: {winners} won with a Straight!"; }
                return $"Player: {winners} won with a Straight!";
            }

            if (Flush.Count > 0)
            {
                foreach (WinnerModels player in Flush)
                {
                    winners = $"{winners} {player.playerId}";
                }
                if (Flush.Count > 1) { return $"It's a tie! Players: {winners} won with a Flush!"; }
                return $"Player: {winners} won with a Flush!";

            }

            if (Pair.Count > 0)
            {
                if (Pair.Count > 1)
                {
                    int highestHand = -1;
                    int total = 0;
                    foreach (Pair player in Pair)
                    {
                        if (player.Total > highestHand) {
                            highestHand = player.PlayerId;
                            total = player.Total;
                        }
                    }
                    return $"Player: {highestHand} has won with the highest Pair {total}";
                }
                foreach (Pair player in Pair)
                {
                    return $"Player: {player.PlayerId} has won with the highest Pair {player.Total}";
                }
            }

            return $"Player: {highestcard.playerId} has won with the highest card {highestcard.Total}";
        }
    }
}
