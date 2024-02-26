//Board class

using System.Drawing;

namespace Assignment2
{
    class Board
    {

        public Cell[,] Grid = new Cell[6, 6];
        string[,] boardSkeleton = { { "P1", "-", "-", "-", "-", "-" }, { "-", "-", "-", "-", "-", "-" }, { "-", "-", "-", "-", "-", "-" }, { "-", "-", "-", "-", "-", "-" }, { "-", "-", "-", "-", "-", "-" }, { "-", "-", "-", "-", "-", "P2" } };
        int gemInBoard;
        double gemMedian;
        bool gemCheck = false;
        public int highlightPlayer = 0;

        Random random = new Random();

        Cell cell = new Cell();

        //Constructor for initializing the board with players, gems, and obstacles.
        public Board()
        {
            gemInBoard = random.Next(1, 8);
            int ObstaclesInBoard = random.Next(1, 8);
            RandomPlacement(gemInBoard, 'G');
            RandomPlacement(ObstaclesInBoard, 'O');

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = cell.setOccupant(Grid[i, j], boardSkeleton[i, j]);
                }
            }
            gemMedian = gemInBoard / 2.0;
        }
        
        //Method for randomly placing Obstacles and Gems each time in board
        private void RandomPlacement(int total, char symbol) {
            for (int i = 0; i < total; i++)
            {
                int row = random.Next(6);
                int col = random.Next(6);
                if (boardSkeleton[row, col] == "-")
                {
                    if (symbol == 'O' && ((boardSkeleton[0,1] == "O" && row == 1 && col == 0) || (boardSkeleton[1, 0] == "O" && row == 0 && col == 1) || (boardSkeleton[4, 5] == "O" && row == 5 && col == 4) || (boardSkeleton[5, 4] == "O" && row == 4 && col == 5)))
                    {
                        i--;
                    }
                    else
                    {
                        boardSkeleton[row, col] = symbol.ToString();
                    }
                }
                else
                {
                    i--;
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
                    else if (Grid[i, j].Occupant == "*P1" || Grid[i, j].Occupant == "*P2")
                    {
                        Console.Write("| " + Grid[i, j].Occupant + " ");
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

        //Method to validate the move.
        public Boolean IsValidMove(Player player, char direction)
        {
            bool moveCheck = false;
            int old_x_axis = player.position.X;
            int old_y_axis = player.position.Y;
            player.position.ValidPosition(direction);
            if (direction != 'U' && direction != 'u' && direction != 'D' && direction != 'd' && direction != 'R' && direction != 'r' && direction != 'L' && direction != 'l')
            {
                Console.WriteLine("Invalid direction!!! Try again.");
                moveCheck = false;
            }
            else if (!player.position.isValidPosition)
            {
                Console.WriteLine($"Wrong movement! Cannot move to {direction} direction. Try again.");
                moveCheck = false;
            }
            else if (Grid[player.position.coordinates[0], player.position.coordinates[1]].Occupant=="O")
            {
                Console.WriteLine("Oops, there is an obstacle, please make another move.");
                moveCheck = false;
            }
            else if (Grid[player.position.coordinates[0], player.position.coordinates[1]].Occupant == "P1" || Grid[player.position.coordinates[0], player.position.coordinates[1]].Occupant == "P2")
            {
                Console.WriteLine("Watch out, please make another move.");
                moveCheck = false;
            }
            else
            {
                moveCheck = true;
            }
            player.position.isValidPosition = true;
            return moveCheck;
        }

        //Method to check if the player's new position contains a gem and updates the player's GemCount.
        public void CollectGem(Player player)
        {
            if(Grid[player.position.X, player.position.Y].Occupant == "G")
            {
                player.GemCount++;
                Console.WriteLine($"Woo-hoo, {player.Name} got a GEM!");
                gemInBoard--;
                highlightPlayer = 1;
                if (player.GemCount > gemMedian)
                {
                    gemCheck = true;
                }
            }
        }

        //Method to check if the board contains Gem;
        //Useful in game over conditions.
        public bool CheckGemInBoard()
        {
            bool isGemInBoard = true;
            if (gemCheck)
            {
                isGemInBoard = false;
            }
            if(gemInBoard  == 0)
            {
                isGemInBoard= false;
            }
            return isGemInBoard;
        }
    }
}