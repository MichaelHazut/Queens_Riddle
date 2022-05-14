using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens_Riddle
{
    internal class CheckersBoard
    {
        private int count = 0;
        public string[,] board;
        private static readonly object key = new object();

        public CheckersBoard()
        {
            board = new string[8, 8];
        }
        public string[,] EmptyBoard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    this.board[i, j] = "Empty";
            return board;
        }

        public string[,] PlaceQueen()
        {
            lock (key) { }
            int failsafe = 0;
            for (int i = 0; i < 8; i++)
            {
                while (true)
                {
                    int rnd = new Random().Next(0, 8);
                    if (this.ChackSquer(i, rnd))
                    {
                        board[i, rnd] = "Queen";
                        BlockSquers(i, rnd);
                        break;
                    }
                    else
                    {
                        failsafe++;
                        if (failsafe == 200)
                        {
                            count++;
                            Console.WriteLine($"try number: {count}");
                            this.EmptyBoard();
                            PlaceQueen();
                            i += 10;
                            break;
                        }
                    }
                }
            }
            return board;
        }
        public void BlockSquers(int y, int x)
        {
            //X axis

            for (int i = x + 1; i < 8; i++)
            {
                if (board[y, i] == "Queen") continue;
                board[y, i] = "Danger";
            }
            for (int i = x - 1; i >= 0; i--)
            {
                if (board[y, i] == "Queen") continue;
                board[y, i] = "Danger";
            }

            //Y axis
            for (int i = y + 1; i < 8; i++)
            {
                if (board[i, x] == "Queen") continue;
                board[i, x] = "Danger";
            }
            for (int i = y - 1; i >= 0; i--)
            {
                if (board[i, x] == "Queen") continue;
                board[i, x] = "Danger";
            }

            //cross axis down till up
            for (int i = y + 1, j = x + 1; i < 8 && j < 8; i++, j++)
            {
                if (board[i, j] == "Queen") continue;
                board[i, j] = "Danger";
            }
            for (int i = y - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == "Queen") continue;
                board[i, j] = "Danger";
            }

            //cross axis up till down
            for (int i = y + 1, j = x - 1; i < 8 && j >= 0; i++, j--)
            {
                if (board[i, j] == "Queen") continue;
                board[i, j] = "Danger";
            }
            for (int i = y - 1, j = x + 1; i >= 0 && j < 8; i--, j++)
            {
                if (board[i, j] == "Queen") continue;
                board[i, j] = "Danger";
            }
        }
        public bool ChackSquer(int y, int x)
        {
            if (this.board[y, x] == "Queen" || this.board[y, x] == "Danger")
                return false;
            else
                return true;
        }
        public void PrintBoard(string[,] aBoard)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (aBoard[i, j] == "Empty" || aBoard[i, j] == "Danger")
                        Console.Write("+ ");

                    if (aBoard[i, j] == "Queen")
                        Console.Write("0 ");
                }
                Console.Write($"{i + 1}\n");
            }
            Console.WriteLine("1 2 3 4 5 6 7 8");
            Console.WriteLine("|0| Stands for a Queen");
        }
    }
}
