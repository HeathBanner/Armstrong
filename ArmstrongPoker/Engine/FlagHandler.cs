using System;
namespace ArmstrongPoker.Engine
{
    public class FlagHandler
    {
        public static bool FlagPole()
        {
            Console.Write("Type y or yes if you'd like to continue? ");
            string result = Console.ReadLine();

            switch (result.ToLower())
            {
                case "y":
                    return true;
                case "yes":
                    return true;
                default:
                    return false;
            }
        }
    }
}
