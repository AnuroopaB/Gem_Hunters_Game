namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starting with game and rules.
            Console.WriteLine("<<<<<< Welcome to the GEM HUNT >>>>>>\n");
            Console.WriteLine("\nRules:\n******************************************************************\n" +
                "1. A player can move up, down, left, or right using U, D, L and R.\n" +
                "2. Each player can move only one square on each turn.\n" +
                "3. A player cannot cross obstacles.\n" +
                "4. A player can collect the gem on their way.\n" +
                "5. Player with the most gems collected will be winner.\n" +
                "6. Both the players win, if the game ends in a tie.\n" +
                "******************************************************************");
            Console.Write("\nPress ENTER to start the game...");
            Console.ReadKey();
            game:
            Console.WriteLine("\n\nGAME STARTS NOW!");
            //Creating object for class Game to start the game;
            //Constructor and methods can be called.
            Game game = new Game();
            game.Start();
            //User decision to continue or quit the game.
            Console.Write("\nThankyou for playing the game.\n\nDo you want to play again? (Yes/No) : ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "yes")
            {
                goto game;
            }
            else
            {
                Console.WriteLine("\nBye! Come back soon.\n");
            }
        }
    }
}
