using System;

namespace Queens_Riddle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckersBoard board = new CheckersBoard();
            board.EmptyBoard();
            board.PrintBoard(board.PlaceQueen());
        }
    }
}
