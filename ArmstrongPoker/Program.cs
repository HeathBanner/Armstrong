using System;
using System.Collections.Generic;
using ArmstrongPoker.Engine;
using static ArmstrongPoker.Engine.LobbyConstructor;
using static ArmstrongPoker.Engine.FlagHandler;
using ArmstrongPoker.Models;

namespace ArmstrongPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;

            Console.WriteLine("\nWelcome! Remember, the more players, the more it gets interesting.\n");

            while (flag)
            {
                //Get the number of players
                int result = LobbyConstructor.LobbyNum();

                //Create the players and their hands
                List<Player> newLobby = LobbyInit(result);

                //Iterate through the players to find the winner(s)
                Winner.CheckList(newLobby);

                //Accepts input on whether the use would like to continue
                flag = FlagPole();
            }

            Console.WriteLine("\nThank you for playing!\n");
        }
    }
}
