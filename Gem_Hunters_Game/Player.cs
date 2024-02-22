//Player class
namespace Assignment2
{
    class Player
    {
        public string Name;
        public Position position;
        public int GemCount = 0;

        //Method for updating the player's position based on the input direction.
        public void Move(char direction) 
        {
            int row = position.X;
            int column = position.Y;
            if (direction == 'U' || direction == 'u')
            {
                row -= 1;
                position = new Position(row, column);
            }
            else if (direction == 'D' || direction == 'd')
            {
                row += 1;
                position = new Position(row, column);
            }
            else if (direction == 'R' || direction == 'r')
            {
                column += 1;
                position = new Position(row, column);
            }
            else
            {
                column -= 1;
                position = new Position(row, column);
            }
        }
    }
}