using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ArmstrongPoker.Models;
using static ArmstrongPoker.Engine.Finalize;

namespace ArmstrongPoker.Engine
{
    class Winner
    {
        public void CheckList(List<Player> players)
        {
            List<WinnerModels> RoyalList = new List<WinnerModels>();
            List<WinnerModels> ToKList = new List<WinnerModels>();
            List<WinnerModels> StraightList = new List<WinnerModels>();
            List<WinnerModels> FlushList = new List<WinnerModels>();
            List<WinnerModels> PairList = new List<WinnerModels>();
            HighestCard highestcard = new HighestCard { Total = 0, playerId = -1 };
            Royalty royalty = new Royalty { HighestRoyal = "Commoner", playerId = -1 };

            foreach (Player aPlayer in players)
            {
                bool isToK = ToK(aPlayer);
                bool isStraight = Straight(aPlayer);
                bool isFlush = Flush(aPlayer);
                bool isPair = Pair(aPlayer);

                int pHighCard = HighCard(aPlayer);
                string pRoyal = CheckRoyalty(aPlayer);

                //Append player info if it reaches one of the conditionals
                if (isToK) { ToKList.Add(new WinnerModels { playerId = aPlayer.Id, Total = pHighCard }); }
                if (isStraight && isFlush) { RoyalList.Add(new WinnerModels { playerId = aPlayer.Id, Total = pHighCard }); }
                if (isStraight) { StraightList.Add(new WinnerModels { playerId = aPlayer.Id, Total = pHighCard }); }
                if (isFlush) { FlushList.Add(new WinnerModels { playerId = aPlayer.Id, Total = pHighCard }); }
                if (isPair) { PairList.Add(new WinnerModels { playerId = aPlayer.Id, Total = pHighCard }); }
                if (pHighCard > highestcard.Total) {
                    highestcard = new HighestCard { playerId = aPlayer.Id, Total = pHighCard };
                }
                if (BloodLine(pRoyal, ref royalty)) {
                    royalty = new Royalty { HighestRoyal = pRoyal, playerId = aPlayer.Id };
                }

                //Display the players' hands
                Console.WriteLine("{0}: {1}{2}, {3}{4}, {5}{6}",
                    aPlayer.Id,
                    aPlayer.Card1.Rank, aPlayer.Card1.Suit,
                    aPlayer.Card2.Rank, aPlayer.Card2.Suit,
                    aPlayer.Card3.Rank, aPlayer.Card3.Suit);
            }

            //Display the winner(s)
            Console.WriteLine("\n {0} \n\nPress Enter to continue",
                WhoWon(RoyalList, ToKList,
                StraightList, FlushList,
                PairList, highestcard,
                royalty));

            Console.ReadLine();
        }

        static bool ToK(Player player)
        {
            var rank = player.Card1.Rank;

            if (player.Card2.Rank == rank && player.Card3.Rank == rank) { return true; }

            return false;
        }

        static bool Straight(Player player)
        {
            //Order the card ranks in Ascending Order
            var cardOne = InterpretRank(player.Card1);
            var cardTwo = InterpretRank(player.Card2);
            var cardThree = InterpretRank(player.Card3);

            var order = $"{cardOne}{cardTwo}{cardThree}";
            var sorted = order.OrderBy(i => i);

            Regex rx = new Regex(@"/123|234|345|456|567|678|789|8910|91011|101112|111213/", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var matches = rx.Matches(order);

            if (matches.Count > 0) { return true; }

            return false;
        }

        static bool Flush(Player player)
        {
            var suit = player.Card1.Suit;

            if (suit == player.Card2.Suit && suit == player.Card3.Suit) { return true; }

            return false;
        }

        static bool Pair(Player player)
        {
            var card1 = player.Card1.Rank;
            var card2 = player.Card2.Rank;
            var card3 = player.Card3.Rank;

            if (card1 == card2 || card1 == card3) return true;
            if (card2 == card1 || card2 == card3) return true;
            if (card3 == card1 || card3 == card2) return true;

            return false;
        }

        static int HighCard(Player player)
        {
            var cardOne = InterpretRank(player.Card1);
            var cardTwo = InterpretRank(player.Card2);
            var cardThree = InterpretRank(player.Card3);

            int result = cardOne + cardTwo + cardThree;

            return result;
        }

        static int InterpretRank(Card card)
        {
            switch (card.Rank)
            {
                case "A":
                    return 1;
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                default:
                    return Int32.Parse(card.Rank);
            }
        }

        private string CheckRoyalty(Player player)
        {
            var card1 = player.Card1.Rank;
            var card2 = player.Card2.Rank;
            var card3 = player.Card3.Rank;

            if (card1 == "A" || card2 == "A" || card3 == "A") return "A";
            if (card1 == "K" || card2 == "K" || card3 == "K") return "K";
            if (card1 == "Q" || card2 == "Q" || card3 == "Q") return "Q";
            if (card1 == "J" || card2 == "J" || card3 == "J") return "J";

            return "Commoner";
        }

        private bool BloodLine(string royal, ref Royalty royalty)
        {
            string highest = royalty.HighestRoyal;

            if (royal == "A" && (highest == "K" || highest == "Q" || highest == "J" || highest == "Commoner")) return true;
            if (royal == "K" && (highest == "Q" || highest == "J" || highest == "Commoner")) return true;
            if (royal == "Q" && (highest == "J" || highest == "Commoner")) return true;
            if (royal == "J" && highest == "Commoner") return true;

            return false;
        }
    }
}
