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
            int x_axis = player.position.X;
            int y_axis = player.position.Y;

            if (direction == 'U' || direction == 'u')
            {
                x_axis -= 1;
            }
            if (direction == 'D' || direction == 'd')
            {
                x_axis += 1;
            }
            if (direction == 'R' || direction == 'r')
            {
                y_axis += 1;
            }
            if (direction == 'L' || direction == 'l')
            {
                y_axis -= 1;
            }


            if (direction != 'U' && direction != 'u' && direction != 'D' && direction != 'd' && direction != 'R' && direction != 'r' && direction != 'L' && direction != 'l')
            {
                Console.WriteLine("Wrong movement!!! Try again.");
                moveCheck = false;
            }
            else if (Grid[x_axis, y_axis].Occupant=="O")
            {
                Console.WriteLine("Oops, there is an obstacle, please make another move.");
                moveCheck = false;
            }
            else if (x_axis < 0 || x_axis > 5 || y_axis < 0 || y_axis > 5)
            {
                Console.WriteLine($"Invalid movement! Cannot move to {direction} direction. Try again next time.");
                moveCheck = false;
            }
            else
            {   
                player.position = new Position(x_axis, y_axis);
                player.Move(direction);
                moveCheck = true;
            }
            return moveCheck;
        }
        public int CollectGem(Player player)
        {
            return 0;
        }
    }
}