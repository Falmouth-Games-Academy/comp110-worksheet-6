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
        public Mark[,] Squares;

        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(/* int width = 3, int height = 3, int inARow = 3 */)
		{
            //Sets up the boards values and sets them all to none
            Squares = new Mark[3, 3];

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Squares[x, y] = Mark.None;
                }
            }
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            Mark value = Squares[x, y];
            return value;
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            bool taken;

            if (Squares[x, y] == Mark.None)
            {
                Squares[x, y] = mark;
                taken = true;
            }

            else
            {
                taken = false;
            }

            return taken;
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
            bool full;
            int remaining = 0;

            // Counts number of empty squares
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (Squares[x, y] == Mark.None)
                    {
                        remaining++;
                    }
                }
            }

            // Returns true only if there are no empty squares
            if (remaining > 0)
            {
                full = false;
            }

            else
            {
                full = true;
            }

            return full;
        }

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
            Mark winner = Mark.None;

            // Checks if any X rows are all one type
            for (int x = 0; x < 3; x++)
            {
                int Xrow = 0;
                int Orow = 0;

                for (int y = 0; y < 3; y++)
                {
                    if (Squares[x, y] == Mark.X)
                    {
                        Xrow++;
                    }

                    else if (Squares[x, y] == Mark.O)
                    {
                        Orow++;
                    }

                    if(Xrow == 3)
                    {
                        winner = Mark.X;
                    }

                    if (Orow == 3)
                    {
                        winner = Mark.O;
                    }
                }
            }

            // Checks if any Y rows are all one type
            for (int y = 0; y < 3; y++)
            {
                int Xrow = 0;
                int Orow = 0;

                for (int x = 0; x < 3; x++)
                {
                    if (Squares[x, y] == Mark.X)
                    {
                        Xrow++;
                    }

                    else if (Squares[x, y] == Mark.O)
                    {
                        Orow++;
                    }

                    if (Xrow == 3)
                    {
                        winner = Mark.X;
                    }

                    if (Orow == 3)
                    {
                        winner = Mark.O;
                    }
                }
            }


            // Checks if the down diagonal is all one type
            if (Squares[0,0] == Squares[1,1] && Squares[0, 0] == Squares[2, 2])
            {
                winner = Squares[0, 0];
            }

            // Checks if the up diagonal is all one type
            if (Squares[0, 2] == Squares[1, 1] && Squares[0, 2] == Squares[2, 0])
            {
                winner = Squares[0, 2];
            }

            return winner;
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

