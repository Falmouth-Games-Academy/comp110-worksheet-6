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
        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        Mark[,] board;

        public OxoBoard(int width = 3, int height = 3, int inARow = 3)
		{
            board = new Mark[width,height];
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            return board[x,y];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            if (x < board.GetLength(0) && y < board.GetLength(1))
            {
                if (board[x,y] == Mark.None)
                {
                    board[x,y] = mark;
                    return true;
                }
            }

            return false;
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x,y] == Mark.None)
                    {
                        return false;
                    }
                }
            }

            return true;
		}

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
            foreach (Mark mark in new Mark[] { Mark.O, Mark.X })
            {
                if (CheckNegDiagonalMark(mark) || CheckPosDiagonalMark(mark))
                {
                    return mark;
                }

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (CheckHorizontalMark(mark, i) || CheckVerticalMark(mark, i))
                    {
                        return mark;
                    }
                }
            }

            return Mark.None;
		}

        public bool CheckHorizontalMark(Mark mark, int y)
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

        public bool CheckVerticalMark(Mark mark, int x)
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

        public bool CheckNegDiagonalMark(Mark mark)
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

        public bool CheckPosDiagonalMark(Mark mark)
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

