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
		private Mark[] board;

		// Constructor. Perform any necessary data initialisation here.
		// Uncomment the optional width and height parameters if attempting the stretch goal.
		public OxoBoard(/* int width = 3, int height = 3 */)
		{
			board = new Mark[9];
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
			return board[y * 3 + x];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
			int i = y * 3 + x;

			if (board[i] == Mark.None)
			{
				board[i] = mark;
				return true;
			}
			else
			{
				return false;
			}
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
			return !board.Contains(Mark.None);
		}

		private Mark checkLine(int start, int delta)
		{
			var p = board[start];
			return (board[start + delta] == p && board[start + 2 * delta] == p) ? p : Mark.None;
		}

		private IEnumerable<Mark> checkLines()
		{
			for(int i=0; i<3; i++)
			{
				yield return checkLine(i * 3, 1); // horizontal
				yield return checkLine(i, 3); // vertical
			}

			// Diagonals
			yield return checkLine(0, 3 + 1);
			yield return checkLine(2, 3 - 1);
		}

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
			foreach (var p in checkLines())
				if (p != Mark.None)
					return p;
			return Mark.None;
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

