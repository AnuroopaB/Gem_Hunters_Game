//Game class
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Assignment2
{
    class Game
    {
        Board board;
        Player player1;
        Player player2;
        Player CurrentTurn;
        int TotalTurns = 0;
        bool check = false;
        int x, y, highlightPlayer;

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
            char direction;
            String oldOccupant;
            Console.Write("\nEnter name for Player 1: ");
            player1.Name = Console.ReadLine();
            player1.position = new Position(0,0);
            Console.Write("Enter name for Player 2: ");
            player2.Name = Console.ReadLine();
            player2.position = new Position(5, 5);
            Console.WriteLine($"\n{player1.Name.ToUpper()} [P1] vs {player2.Name.ToUpper()} [P2]\n");
            CurrentTurn = player1;
            board.Display();
            while (!IsGameOver())
            {
                x = CurrentTurn.position.X; y = CurrentTurn.position.Y;
                Console.Write($"\n{CurrentTurn.Name}'s Turn: ");
                direction = char.Parse(Console.ReadLine());
                if (board.IsValidMove(CurrentTurn, direction))
                {
                    CurrentTurn.Move(direction);
                    board.CollectGem(CurrentTurn);
                    oldOccupant = board.Grid[x, y].Occupant;
                    ChangeInBoard(oldOccupant);
                    board.Grid[x, y].Occupant = "-";
                    Console.Write("\n");
                    board.Display();
                    SwitchTurn();
                    TotalTurns++;
                }
            }
            Console.WriteLine("\n***" + AnnounceWinner() + "***");
            Console.Write("\nPress 1 to view the score; Press 2 to Continue or exit the game: ");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                Console.WriteLine("\n"+new string('*', 50));
                Console.WriteLine($"*\n*\t{player1.Name} collected {player1.GemCount} {(player1.GemCount<2 ? "gem" : "gems")}.\n*\n*\t{player2.Name} collected {player2.GemCount} {(player2.GemCount < 2 ? "gem" : "gems")}.\n*");
                Console.WriteLine(new string('*', 50));
            }
        }
        //Method for switching between Player1 and Player2 turns.
        private void SwitchTurn()
        {
               CurrentTurn = (CurrentTurn == player1 ? player2 : player1);
        }
        //Method to check if the game has reached its end condition.
        private bool IsGameOver()
        {
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
        private string AnnounceWinner()
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
        //Method for making movement in board; also highlight the gem collected player cell.
        private void ChangeInBoard(string oldOccupant)
        {
            string passedOccupant = oldOccupant;
            if (board.highlightPlayer == 1)
            {
                if (oldOccupant.Contains('*'))
                {
                    board.Grid[CurrentTurn.position.X, CurrentTurn.position.Y].Occupant = oldOccupant;
                    board.highlightPlayer = 2;
                }
                else
                {
                    board.Grid[CurrentTurn.position.X, CurrentTurn.position.Y].Occupant = "*" + oldOccupant;
                    board.highlightPlayer = 2;
                }
            }
            else if (board.highlightPlayer == 2 && oldOccupant.Contains('*'))
            {
                board.Grid[CurrentTurn.position.X, CurrentTurn.position.Y].Occupant = oldOccupant.Substring(1);
            }
            else
            {
                board.Grid[CurrentTurn.position.X, CurrentTurn.position.Y].Occupant = oldOccupant;
            }
            //highlightPlayer = 0;
        }
    }
}