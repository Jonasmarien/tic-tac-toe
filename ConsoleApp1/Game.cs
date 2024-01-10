namespace TicTacToe
{
    /// <summary>
    /// The TicTacToe class handles the flow of the game itself
    /// It utilizes a Board and Players to coordinate the Tic Tac Toe game
    /// </summary>
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private Board _board;
        private bool _player1Turn = true;

        public bool IsOngoing => !_board.HasLine && !_board.IsFull();

        public static Game Start()
        {
            Console.Write("Player 1: ");
            var name1 = Console.ReadLine();
            var player1 = new Player()
            {
                Name = name1,
                Marker = Marker.X
            };

            Console.Write("Player 2: ");
            var name2 = Console.ReadLine();
            var player2 = new Player()
            {
                Name = name2,
                Marker = Marker.O
            };

            return new Game(player1, player2);
        }

        public Game(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;

            _board = new Board();
        }

        public void TakeTurn()
        {
            _board.PrintToConsole();

            var currentPlayer = _player1Turn ? _player1 : _player2;
            int position;
            var validInput = false;
            do
            {
                Console.Write($"{currentPlayer.Name}, make your move: ");

                if (!int.TryParse(Console.ReadLine(), out position))
                {
                    Console.WriteLine("Not a number!");
                    continue;
                }

                if (!Enumerable.Range(1, 9).Contains(position))
                {
                    Console.WriteLine("Choose a number between 1 and 9");
                    continue;
                }

                if (!_board.CanPlaceMarkerOnPosition(position))
                {
                    Console.WriteLine("Position already taken!");
                    continue;
                }

                validInput = true;
            }
            while (!validInput);

            _board.PlaceMarker(position, currentPlayer.Marker);
            _player1Turn = !_player1Turn;
        }
    }
}