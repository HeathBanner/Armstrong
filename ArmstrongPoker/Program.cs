using System;
using System.Collections.Generic;
using ArmstrongPoker.Engine;
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
                LobbyConstructor constr = new LobbyConstructor();
                int result = constr.LobbyNum();

                //Create the players and their hands
                List<Player> newLobby = constr.LobbyInit(result);

                //Iterate through the players to find the winner(s)
                Winner winner = new Winner();
                winner.CheckList(newLobby);

                //Accepts input on whether the use would like to continue
                FlagHandler handler = new FlagHandler();
                flag = handler.FlagPole();
            }

            Console.WriteLine("\nThank you for playing!\n");
        }
    }
}
