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
		public OxoBoard(/*int width = 3, int height = 3, int inARow = 3 */)
		{
            playerBoard = new Mark[3, 3];
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int a, int b)
		{
			return playerBoard[a, b];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int a, int b, Mark mark)
		{
            if (playerBoard[a, b] == Mark.None)
            {
                playerBoard[a, b] == mark;
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
            for (int a = 0; a <  playerBoard.GetLength(0); a++)
            {
                for (int b = 0; b < playerBoard.GetLength(0); b++)
                {
                    if (playerBoard[a, b] == Mark.None)
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
            // Verticle
            for (int verticle = 0; verticle <  playerBoard.GetLength(0); verticle++)
            {
                if (playerBoard[verticle, 0] == playerBoard[verticle, 1] && playerBoard[verticle, 2])
                {
                    
                }
            }

            //Horizontal
            for (int horizontal = 0; horizontal <  playerBoard.GetLength(0); horizontal++)
            {
                if (playerBoard[0, horizontal] == playerBoard[1, horizontal] && playerBoard[2, horizontal])
                {
                    
                }
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

