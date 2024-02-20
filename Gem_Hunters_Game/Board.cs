//Board class
using System.Runtime.Intrinsics.X86;
using static System.Collections.Specialized.BitVector32;

namespace Assignment2
{
    class Board
    {
        
        public Cell[,] Grid = new Cell[6, 6];
        public string[,] b1 = { { "P1", "-", "-", "O", "-", "-" }, { "-", "G", "-", "-", "O", "-" }, { "O", "-", "-", "G", "-", "-" }, { "G", "-", "-", "-", "-", "O" }, { "-", "O", "-", "G", "-", "-" }, { "-", "-", "G", "-", "-", "P2" } };
       
        Cell cell = new Cell();

        //Constructor for initializing the board with players, gems, and obstacles.
        public Board()
        {

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i,j] = cell.setOccupant(Grid[i, j], b1[i, j]);
                }
            }
        }
        //Method for displaying the board.
        public void Display()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("-------------------------------------");
                for (int j = 0; j < 6; j++)
                {
                    if (Grid[i, j].Occupant == "P1" || Grid[i, j].Occupant == "P2")
                    {
                        Console.Write("|  " + Grid[i, j].Occupant + " ");
                    }
                    else
                    {
                        Console.Write("|  " + Grid[i, j].Occupant + "  ");
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("-------------------------------------");
        }
        public Boolean IsValidMove(Player player, char direction)
        {
            Boolean moveCheck = false;
            
            return moveCheck;
        }
        public int CollectGem(Player player)
        {
            return 0;
        }
    }
}