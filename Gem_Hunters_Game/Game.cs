//Game class
using System.Numerics;

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

        //Method for starting the game, displaying the board, and alternates player turns.
        public void Start()
        {
            board.Display();
            player1.Name = "P1";
            player1.position = new Position(0,0);
            player1.GemCount = 0;
            player2.Name = "P2";
            player2.position = new Position(5, 5);
            player2.GemCount = 0;
            SwitchTurn();
        }
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
                    //CurrentTurn.Move(direction, board);
                    board.Display();
                    TotalTurns++;
                }
                else
                {
                    goto loop1;
                }
            }
        }
        public Boolean IsGameOver()
        {
            Boolean check = false;
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
        public string AnnounceWinner()
        {
            return ("U won");
        }
    }
}