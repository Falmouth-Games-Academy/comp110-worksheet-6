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
		public OxoBoard(/* int width = 3, int height = 3, int inARow = 3 */)
		{
			board = new Mark[3, 3];
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
			return board[x, y];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
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

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
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

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
            // This will check every horizontal potential win for player "X"
			if(board[0,0] == Mark.X && board[1, 0] == Mark.X && board[2, 0] == Mark.X)
            {
                return Mark.X;
            }
            else if (board[0, 1] == Mark.X && board[1, 1] == Mark.X && board[2, 1] == Mark.X)
            {
                return Mark.X;
            }
            else if (board[0, 2] == Mark.X && board[1, 2] == Mark.X && board[2, 2] == Mark.X)
            {
                return Mark.X;
            }

            // This will check every horizontal potential win for player "O"
            else if (board[0, 0] == Mark.O && board[1, 0] == Mark.O && board[2, 0] == Mark.O)
            {
                return Mark.O;
            }
            else if (board[0, 1] == Mark.O && board[1, 1] == Mark.O && board[2, 1] == Mark.O)
            {
                return Mark.O;
            }
            else if (board[0, 2] == Mark.O && board[1, 2] == Mark.O && board[2, 2] == Mark.O)
            {
                return Mark.O;
            }

            // This will check every vertical potential win for player "X"

            else if (board[0, 0] == Mark.X && board[0, 1] == Mark.X && board[0, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (board[1, 0] == Mark.X && board[1, 1 ] == Mark.X && board[1, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (board[2, 0] == Mark.X && board[2, 1] == Mark.X && board[2, 2] == Mark.X)
            {
                return Mark.X;
            }

            // This will check every vertical potential win for player "O"

            else if (board[0, 0] == Mark.O && board[0, 1] == Mark.O && board[0, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (board[1, 0] == Mark.O && board[1, 1] == Mark.O && board[1, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (board[2, 0] == Mark.O && board[2, 1] == Mark.O && board[2, 2] == Mark.O)
            {
                return Mark.O;
            }

            //  This will check every Diagonal potential win for player "X"

            else if (board[0, 0] == Mark.X && board[1, 1] == Mark.X && board[2, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (board[0, 2] == Mark.X && board[1, 1] == Mark.X && board[2, 0] == Mark.X)
            {
                return Mark.X;
            }
            // This will check every diagonal potential win for player "O"

            else if (board[0, 0] == Mark.O && board[1, 1] == Mark.O && board[2, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (board[0, 2] == Mark.O && board[1, 1] == Mark.O && board[2, 0] == Mark.O)
            {
                return Mark.O;
            }
            else
            {
                return Mark.None;
            }

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

