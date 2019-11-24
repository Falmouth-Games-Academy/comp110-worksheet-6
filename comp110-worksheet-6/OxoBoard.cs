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
        Mark[,] oxoGrid;

        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(/* int width = 3, int height = 3, int inARow = 3 */)
		{
            oxoGrid = new Mark[3, 3];
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            return oxoGrid[x, y];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
			if (GetSquare(x, y) == Mark.None)
            {
                oxoGrid[x, y] = mark;
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
			for (int i = 0; i < oxoGrid.GetLength(0); i++)
            {
                for (int j = 0; j < oxoGrid.GetLength(1); j++)
                {
                    Mark currentMark = oxoGrid[i, j];
                    if (currentMark == Mark.None)
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
            //Checks if player has 3 in a row vertically
            if (oxoGrid[0,0] != Mark.None && oxoGrid[0,0] == oxoGrid[0,1] && oxoGrid[0,2] == oxoGrid[0,0])
            {
                return oxoGrid[0, 0];
            }
            else if (oxoGrid[1, 0] != Mark.None && oxoGrid[1, 0] == oxoGrid[1, 1] && oxoGrid[1, 2] == oxoGrid[1, 0])
            {
                return oxoGrid[1, 0];
            }
            else if (oxoGrid[2, 0] != Mark.None && oxoGrid[2, 0] == oxoGrid[2, 1] && oxoGrid[2, 2] == oxoGrid[2, 0])
            {
                return oxoGrid[2, 0];
            }

            //Checks if player has 3 in a row horizontally
            if (oxoGrid[0, 0] != Mark.None && oxoGrid[1, 0] == oxoGrid[0, 0] && oxoGrid[2, 0] == oxoGrid[0, 0])
            {
                return oxoGrid[0, 0];
            }
            else if (oxoGrid[0, 1] != Mark.None && oxoGrid[1, 1] == oxoGrid[0, 1] && oxoGrid[2, 1] == oxoGrid[0, 1])
            {
                return oxoGrid[0, 1];
            }
            else if (oxoGrid[0, 2] != Mark.None && oxoGrid[1, 2] == oxoGrid[0, 2] && oxoGrid[2, 2] == oxoGrid[0, 2])
            {
                return oxoGrid[0, 2];
            }

            //Checks if player has 3 in a row diagonally
            if (oxoGrid[0, 0] != Mark.None && oxoGrid[1, 1] == oxoGrid[0, 0] && oxoGrid[2, 2] == oxoGrid[0, 0])
            {
                return oxoGrid[0, 0];
            }
            else if (oxoGrid[0, 2] != Mark.None && oxoGrid[1, 1] == oxoGrid[0, 2] && oxoGrid[2, 0] == oxoGrid[0, 2])
            {
                return oxoGrid[0, 2];
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

