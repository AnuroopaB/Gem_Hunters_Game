//Board class
namespace Assignment2
{
    class Board
    {
        public Cell Grid;
        public string[,] b1;
        //Constructor for initializing the board with players, gems, and obstacles.
        public Board()
        {
           b1 = new string[6, 6]{ { "P1", "-", "-", "O", "-", "-" }, { "-", "G", "-", "-", "O", "-" }, { "O", "-", "-", "G", "-", "-" }, { "G", "-", "-", "-", "-", "O" }, { "-", "O", "-", "G", "-", "-" }, { "-", "-", "G", "-", "-", "P2" } };
        }
        //Method for displaying the board.
        public void Display()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("-------------------------------------");
                for (int j = 0; j < 6; j++)
                {
                    if (b1[i, j] == "P1" || b1[i, j] == "P2")
                    {
                        Console.Write("|  " + b1[i, j] + " ");
                    }
                    else
                    {
                        Console.Write("|  " + b1[i, j] + "  ");
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("-------------------------------------");
        }
        public Boolean IsValidMove(Player player, char direction)
        {
            return false;
        }
        public int CollectGem(Player player)
        {
            return 0;
        }
    }
}