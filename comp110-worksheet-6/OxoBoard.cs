using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6
{
    public enum Mark { None, O, X };

    public class OxoBoard
    {
       
        Mark[,] board;
        /// <summary>
        /// Sets the dimensions of the board
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public OxoBoard(int width = 3, int height = 3)
        {
            board = new Mark[width, height];
        }

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y)
        {
            return board[x, y];
        }

        /// <summary>
        /// Checks to make sure that the square selected by the user is empty
        /// Sets the square to the correct mark, as long as it was empty
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        public bool SetSquare(int x, int y, Mark mark)
        {
            if (x < board.GetLength(0) && y < board.GetLength(1))
            {
                if (board[x, y] == Mark.None)
                {
                    board[x, y] = mark;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks to see if the board is full
        /// </summary>
        /// <returns></returns>
        public bool IsBoardFull()
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] == Mark.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks to see if there are any 3 in a row
        /// Returns the winner
        /// </summary>
        /// <returns></returns>
        public Mark GetWinner()
        {
            foreach (Mark mark in new Mark[] { Mark.O, Mark.X })
            {
                if (NegDiagonalMark(mark) || PosDiagonalMark(mark))
                {
                    return mark;
                }

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (HorizontalMark(mark, i) || VerticalMark(mark, i))
                    {
                        return mark;
                    }
                }
            }

            return Mark.None;
        }

        public bool HorizontalMark(Mark mark, int y)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                if (board[x, y] != mark)
                {
                    return false;
                }
            }

            return true;
        }

        public bool VerticalMark(Mark mark, int x)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                if (board[x, y] != mark)
                {
                    return false;
                }
            }

            return true;
        }

        public bool NegDiagonalMark(Mark mark)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, i] != mark)
                {
                    return false;
                }
            }

            return true;
        }

        public bool PosDiagonalMark(Mark mark)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[board.GetLength(0) - 1 - i, i] != mark)
                {
                    return false;
                }
            }

            return true;
        }

        // Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
        public void PrintBoard()
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                if (y > 0)
                    Console.WriteLine(new String('-', 3 * board.GetLength(1)));

                for (int x = 0; x < board.GetLength(0); x++)
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