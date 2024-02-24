//Position class
namespace Assignment2
{
    class Position
    {
        public int X;
        public int Y;
        public bool isValidPosition = true;
        public int[] coordinates;

        //Constructor for updating the position co-ordinates
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        //Method to validate position
        public void ValidPosition(char direction)
        {
            int x1 = X;    
            int y1 = Y;
            if (direction == 'U' || direction == 'u')
            {
                x1 -= 1;
            }
            else if (direction == 'D' || direction == 'd')
            {
                x1 += 1;
            }
            else if (direction == 'R' || direction == 'r')
            {
                y1 += 1;
            }
            else
            {
                y1 -= 1;
            }
            if (x1 < 0 || x1 > 5 || y1 < 0 || y1 > 5)
            {
                isValidPosition = false;
            }
            else
            {
                coordinates = [x1,y1];
            }
        }
    }
}