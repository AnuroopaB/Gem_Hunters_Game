//Cell class
namespace Assignment2
{
    class Cell
    {
        public string Occupant;

        public string getOccupant(Cell x)
        {
            x = new Cell();
            return x.Occupant;
        }
        public Cell setOccupant(Cell y, string x)
        {
            y = new Cell();
            y.Occupant = x;
            return y;
        }
    }
}