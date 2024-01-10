using System;

namespace TicTacToe
{
    public interface IBoard 
    {
        public bool CanPlaceMarker { get; }
        //public void PlaceMarker(TMarker marker, ...);
    }

    /// <summary>
    /// The Board class is a representation of the board itself.
    /// It utilizes a two-dimensional array to place the markers.
    /// </summary>
    /// <typeparam name="TMarker">Identifier for Marker to use</typeparam>
    public class Board : IBoard
    {
        private readonly Marker?[,] _grid;

        public Board()
        {
            _grid = new Marker?[3, 3];
        }

        public bool CanPlaceMarker => throw new NotImplementedException();

        public bool HasLine { get; internal set; }
        public bool IsFull()
        {
            foreach (var position in Enumerable.Range(1, 9))
            {
                (var x, var y) = GetCoordinates(position);
                if (!_grid[x, y].HasValue) return false;
            }

            return true;
        }

        public void PrintToConsole() => Console.WriteLine(
            @$"     
 {PrintMarker(_grid[0, 0])} | {PrintMarker(_grid[0, 1])} | {PrintMarker(_grid[0, 2])} 
-----------   
 {PrintMarker(_grid[1, 0])} | {PrintMarker(_grid[1, 1])} | {PrintMarker(_grid[1, 2])} 
-----------
 {PrintMarker(_grid[2, 0])} | {PrintMarker(_grid[2, 1])} | {PrintMarker(_grid[2, 2])}
            "
        );

        internal bool CanPlaceMarkerOnPosition(int position)
        {
            (var x, var y) = GetCoordinates(position);
            var marker = _grid[x, y];

            return !marker.HasValue;
        }

        internal void PlaceMarker(int position, Marker marker)
        {
            (var x, var y) = GetCoordinates(position);
            _grid[x, y] = marker;
        }

        private (int x, int y) GetCoordinates(int position)
        {
            position -= 1; // Custom-made
            int x = position / 3;
            int y = position % 3;

            return (x, y);
        }

        private string PrintMarker(Marker? marker) => marker.HasValue ? marker.Value.ToString() : "☺️";
    }
}