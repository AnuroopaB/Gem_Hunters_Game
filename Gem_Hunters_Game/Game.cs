//Game class
namespace Assignment2
{
    class Game
    {
        public Board board;
        public Player player1;
        public Player player2;
        public Player CurrentTurn;
        public int TotalTurns = 0;

        //Constructor for initializing the game with a board and two players.
        public Game()
        {
            board = new Board();
            player1 = new Player();
            player2 = new Player();
        }

        //Method for starting the game and displaying the board.
        public void Start()
        {
            Console.Write("\nEnter name for Player 1: ");
            player1.Name = Console.ReadLine();
            player1.position = new Position(0,0);
            player1.GemCount = 0;
            Console.Write("Enter name for Player 2: ");
            player2.Name = Console.ReadLine();
            player2.position = new Position(5, 5);
            player2.GemCount = 0;
            Console.WriteLine($"\n{player1.Name.ToUpper()} [P1] vs {player2.Name.ToUpper()} [P2]\n");
            board.Display();
            SwitchTurn();
        }
        //Method for switching between Player1 and Player2 turns.
        public void SwitchTurn()
        {
            char direction;
            while (!IsGameOver())
            {   
                if(TotalTurns%2 == 0)
                {

                    CurrentTurn = player1;
                }
                else
                {
                     CurrentTurn = player2;
                }
                loop1:
                Console.Write($"\n{CurrentTurn.Name}'s Turn: ");
                direction = char.Parse(Console.ReadLine());
                if (board.IsValidMove(CurrentTurn, direction))
                {
                    Console.Write("\n");
                    board.Display();
                    TotalTurns++;
                }
                else
                {
                    goto loop1;
                }
            }
            Console.WriteLine("\n***"+AnnounceWinner()+"***");
        }
        //Method to check if the game has reached its end condition.
        public bool IsGameOver()
        {
            bool check = false;
            if (!board.CheckGemInBoard())
            {
                check = true;
            }
            if (TotalTurns >= 30)
            {
                check = true;
            }
            return check;

        }
        //Method for identifying and announcing the winner based on GemCount.
        public string AnnounceWinner()
        {
            string result;
            if(player1.GemCount > player2.GemCount)
            {
                result = $"Hurray!!! {player1.Name} won the game. Congratulations!";
            }
            else if (player2.GemCount > player1.GemCount)
            {
                result = $"Hurray!!! {player2.Name} won the game. Congratulations!";
            }
            else
            {
                result = $"Its a tie! {player1.Name} and {player2.Name} won the game. Congratulations!";
            }
            return (result);
        }
    }
}