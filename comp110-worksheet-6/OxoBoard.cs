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
        Mark[,] boardState;
        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        // Initialise 2 Dimensional Array to store board state
        public OxoBoard()
		{
            boardState = new Mark[3, 3];
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            return boardState[x, y];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            if (boardState[x, y] != Mark.None)    // Checks inputted square on board for being empty
            {
                boardState[x, y] = mark;
                return true;    // Sets square to imputted mark and returns true
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
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)    // Utilises a nested for loop to iterate through the multi-dimensional array
                {
                    if (boardState[x, y] == Mark.None)
                    {
                        return false;    // Returns false upon finding an empty space
                    }
                }
            }
            return true;    // Returns true if nested for loop is iterated through without finding an empty space
        }
		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
            if (boardState[0, 0] == boardState[1, 0] && boardState[0, 0] == boardState[2, 0])
            {
                return boardState[0, 0];    // Returns the symbol in the top left corner after comparing it to the rest of the top row
            }                               // This is similarly implemented for each of the if statements below which check one of eight possible win conditions
            else if (boardState[0, 1] == boardState[1, 1] && boardState[0, 1] == boardState[2, 1])
            {
                return boardState[0, 1];
            }
            else if (boardState[0, 2] == boardState[1, 2] && boardState[0, 2] == boardState[2, 2])
            {
                return boardState[0, 2];
            }
            else if (boardState[0, 0] == boardState[0, 1] && boardState[0, 0] == boardState[0, 2])
            {
                return boardState[0, 0];
            }
            else if (boardState[1, 0] == boardState[1, 1] && boardState[1, 0] == boardState[1, 2])
            {
                return boardState[1, 0];
            }
            else if (boardState[2, 0] == boardState[2, 1] && boardState[2, 0] == boardState[2, 2])
            {
                return boardState[2, 0];
            }
            else if (boardState[0, 0] == boardState[1, 1] && boardState[0, 0] == boardState[2, 2])
            {
                return boardState[0, 0];
            }
            else if (boardState[0, 2] == boardState[1, 1] && boardState[0, 1] == boardState[2, 0])
            {
                return boardState[0, 2];
            }
            else
            {
                return Mark.None;    // Returns "None" if no win condition is found
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

