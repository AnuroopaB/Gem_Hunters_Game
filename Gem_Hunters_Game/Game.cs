//Game class
namespace Assignment2
{
    class Game
    {
        public Board board;
        public Player player1;
        public Player player2;
        public Player CurrentTurn;
        public int TotalTurns;

        //Constructor for initializing the game with a board and two players.
        public Game()
        {
            board = new Board();
            player1 = new Player();
            player2 = new Player();
        }

        //Method for starting the game, displaying the board, and alternates player turns.
        public void Start()
        {
            board.Display();
            player1.Name = "P1";
            player1.position = new Position(0,0);
            player1.GemCount = 0;
            player2.Name = "P2";
            player2.position = new Position(6, 6);
            player2.GemCount = 0;
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