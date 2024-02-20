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
        public int TotalTurns = 29;

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
            if(IsGameOver()){
                AnnounceWinner();
            }
            else
            {
                SwitchTurn();
            }
        }
        public void SwitchTurn()
        {
            for(int i = 0; i < TotalTurns; i++)
            {
                if(i%2 == 0)
                {
                    loop1:
                    Console.Write("Player 1's Turn: ");
                    char direction1 = char.Parse(Console.ReadLine());
                    if(board.IsValidMove(player1, direction1))
                    {
                        board.Display();
                    }
                    else
                    {
                        goto loop1;
                    }
                }
                else
                {
                    loop2:
                    Console.Write("Player 2's Turn: ");
                    char direction2 = char.Parse(Console.ReadLine());
                    if(board.IsValidMove(player2, direction2))
                    {
                        board.Display(); ;
                    }
                    else
                    {
                        goto loop2;
                    }
                }
            }
        }
        public Boolean IsGameOver()
        {
            Boolean check = false;
            return check;

        }
        public string AnnounceWinner()
        {
            return ("U won");
        }
    }
}