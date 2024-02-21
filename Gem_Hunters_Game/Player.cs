//Player class
using System.ComponentModel.Design;
using System.Numerics;

namespace Assignment2
{
    class Player
    {
        public string Name;
        public Position position;
        public int GemCount = 0;

        public void Move(char direction) 
        {
            int row = position.X;
            int column = position.Y;
            
        }
    }
}