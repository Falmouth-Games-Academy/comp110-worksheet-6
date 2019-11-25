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

        Mark[,] GameBoard;

		// Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
		public OxoBoard(int width = 3, int height = 3, int inARow = 3)
		{
            //Creating the board
            GameBoard = new Mark[width, height];
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            return GameBoard[x, y];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            //Added validation for the users inputs
            if (x < GameBoard.GetLongLength(0) && y < GameBoard.GetLongLength(1) && x > -1 && y > -1)
            {
                if (GameBoard[x, y] == Mark.None)
                {
                    GameBoard[x, y] = mark;
                    return true;
                }
            } 
            return false;
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
            //iterating through the columns
			for(int i = 0; i < GameBoard.GetLongLength(0); i++)
            {
                //iterating through the rows
                for(int j = 0; j < GameBoard.GetLongLength(1); j++)
                {
                    //if the current position is empty, it will return false
                    if (GameBoard[i, j] == Mark.None)
                    {
                        return false;
                    }
                    
                }

            }
            //if the previous statements are not true, then it will return true
            return true;
		}

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
            //iterating through the rows
			for (int horizontal = 0; horizontal < GameBoard.GetLongLength(0); horizontal++)
            {
                //checking if the contents of each position are the same for three in a row
                if (GameBoard[horizontal, 0] == GameBoard[horizontal, 1] && GameBoard[horizontal, 1] == GameBoard[horizontal, 2])
                {
                    //checking if the tiles are player tiles or empty
                    if(GetSquare(horizontal, 0) != Mark.None)
                    {
                        return GetSquare(horizontal, 0);
                    }

                }
            }
            //repeating the above process for the columns
            for (int vertical = 0; vertical < GameBoard.GetLongLength(1); vertical++)
            {
                if (GameBoard[0, vertical] == GameBoard[1, vertical] && GameBoard[1, vertical] == GameBoard[2, vertical])
                {
                    if(GetSquare(0, vertical) != Mark.None)
                    {
                        return GetSquare(0 ,vertical);
                    }
                }
            }
            //checking on a diagonal
            if (GameBoard[0, 0] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[2, 2])
            {
                return GetSquare(0, 0);
            }
            if (GameBoard[2, 0] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[0, 2])
            {
                return GetSquare(2, 0);
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

