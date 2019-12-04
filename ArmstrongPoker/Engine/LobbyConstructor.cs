using System;
using System.Collections.Generic;
using ArmstrongPoker.Models;

namespace ArmstrongPoker.Engine
{
    class LobbyConstructor
    {
        public int LobbyNum()
        {
            int numPlayers = 0;

            while (numPlayers <= 0 || numPlayers >= 24)
            {
                Console.Write("\nEnter the amount of players (1 - 23): ");
                var input = Console.ReadLine();

                bool validNum = int.TryParse(input, out numPlayers);

                if (numPlayers <= 0 || numPlayers >= 24 || !validNum)
                {
                    Console.WriteLine("\nThe number of players should be from 1-24. Press enter to continue");
                }
            }

            return numPlayers;
        }

        public List<Player> LobbyInit(int x)
        {
            List<Player> players = new List<Player>();

            string[] Suits = { "h", "d", "s", "c" };
            string[] Ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            //Create each player and their hand
            for (int i = 0; i < x; i++)
            {
                Random rnd = new Random();

                Card card1 = new Card{ Rank = Ranks[rnd.Next(0, 13)], Suit = Suits[rnd.Next(0, 4)] };
                Card card2 = new Card { Rank = Ranks[rnd.Next(0, 13)], Suit = Suits[rnd.Next(0, 4)] };
                Card card3 = new Card { Rank = Ranks[rnd.Next(0, 13)], Suit = Suits[rnd.Next(0, 4)] };

                players.Add(new Player { Id = i, Card1 = card1, Card2 = card2, Card3 = card3 });
            }

            return players;
        }
    }
}
