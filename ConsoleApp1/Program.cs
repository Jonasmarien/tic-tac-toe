using TicTacToe;

var game = Game.Start();

do game.TakeTurn();
while (game.IsOngoing);
