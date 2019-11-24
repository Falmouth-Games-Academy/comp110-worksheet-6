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
        public Mark[,] Board;

        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(/* int width = 3, int height = 3, int inARow = 3 */)
		{
            Board = new Mark[3, 3] { { 0, 0, 0 },
                                     { 0, 0, 0 },
                                     { 0, 0, 0 } };

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
            if (Board[x, y] == 0)
            {
                Board[x, y] = mark;
                return true;
            }

            return false;
        }

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i,j] == 0)
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
            // Horizontal.
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                if (Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2])
                {
                    return Board[i, 0];
                }
            }

            // Vertical.
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                if (Board[0, j] == Board[1, j] && Board[1, j] == Board[2, j])
                {
                    return Board[0, j];
                }
            }

            // Diagonals.
            if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            {
                return Board[0, 0];
            }
            if (Board[2, 0] == Board[1, 1] && Board[1, 1] == Board[0, 2])
            {
                return Board[2, 0];
            }

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

