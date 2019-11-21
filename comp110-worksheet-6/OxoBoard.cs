using System;
using System.Collections.Generic;

namespace comp110_worksheet_6
{
    public enum Mark { None, O, X };

    public class OxoBoard
    {
        private int BoardWidth;
        private int BoardHeight;
        private Mark[,] Board;
        private int InARow;

        private readonly int WinConditionCount = 8;
        // TODO:
        private readonly List<int[,]> WinConditions = new List<int[,]> {
             new int [3,2] { { 0, 0 }, { 0, 1 }, { 0, 2} },
             new int [3,2] { { 1, 0 }, { 1, 1 }, { 1, 2} },
             new int [3,2] { { 2, 0 }, { 2, 1 }, { 2, 2} },
             new int [3,2] { { 0, 0 }, { 1, 0 }, { 2, 0} },
             new int [3,2] { { 0, 1 }, { 1, 1 }, { 2, 1} },
             new int [3,2] { { 0, 2 }, { 1, 2 }, { 2, 2} },
             new int [3,2] { { 0, 0 }, { 1, 1 }, { 2, 2} },
             new int [3,2] { { 2, 0 }, { 1, 1 }, { 0, 2} },
        };




        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(int width = 3, int height = 3, int inARow = 3)
        {
            BoardWidth = width;
            BoardHeight = height;
            Board = new Mark[BoardWidth, BoardHeight];
            InARow = inARow;
        }

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y)
        {
            return Board[x, y];
        }

        // If the specified square is currently empty, fill it with mark and return true.
        // If the square is not empty, leave it as-is and return False.
        public bool SetSquare(int x, int y, Mark mark)
        {
            bool result = Board[x, y] == Mark.None ? true : false;
            if (result) Board[x, y] = mark;
            return result;
        }

        // If there are still empty squares on the board, return false.
        // If there are no empty squares, return true.
        public bool IsBoardFull()
        {
            for (int x = 0; x < BoardWidth; x++)
            {
                for (int y = 0; x < BoardHeight; y++)
                {
                    if (Board[x, y] == Mark.None) return true;
                }
            }
            return false;
        }

        // If a player has three in a row, return Mark.O or Mark.X depending on which player.
        // Otherwise, return Mark.None.
        public Mark GetWinner()
        {
            for (int win = 0; win < WinConditionCount; win++)
            {
                for (int col = 0; col < BoardWidth; col++)
                {
                    var condition = WinConditions[win];
                    for (int row = 0; row < 3; row++)
                    {
                        Mark square = GetSquare();
                    }
                }
            }
            throw new NotImplementedException("TODO: implement this function and then remove this exception");
        }

        // Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
        public void PrintBoard()
        {
            for (int y = 0; y < 3; y++)
            {
                if (y > 0)
                    Console.WriteLine("--+---+--");

                for (int x = 0; x < 3; x++)
                {
                    if (x > 0)
                        Console.Write(" | ");

                    switch (GetSquare(x, y))
                    {
                        case Mark.None:
                            Console.Write(" "); break;
                        case Mark.O:
                            Console.Write("O"); break;
                        case Mark.X:
                            Console.Write("X"); break;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}

