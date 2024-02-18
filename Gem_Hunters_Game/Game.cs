using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Numerics;

namespace Assignment2
{
    class Game
    {
        public Board board;
        public Player player1;
        public Player player2;
        public Player CurrentTurn;
        public int TotalTurns;
        public Game()
        {
        }

        public void Start()
        {
        }
        public void SwitchTurn()
        {
        }
        public void IsGameOver()
        {
        }
        public string AnnounceWinner()
        {
            return ("U won");
        }
    }
}