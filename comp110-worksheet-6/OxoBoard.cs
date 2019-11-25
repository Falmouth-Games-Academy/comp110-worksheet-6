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

		//Initialise the board variable, which will be assigned to in OxoBoard().
		Mark[,] board;
		int numForARow;

		// Constructor. Perform any necessary data initialisation here.
		// Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
		public OxoBoard(int width = 3, int height = 3, int inARow = 3)
		{
			//Assigning values to variables
			board = new Mark[width, height];
			numForARow = inARow;
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
			//Will return Mark for the specific board cell
			return board[x, y];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
			//Try and catch are used to stop values that are more than or less than the size of the grid.
			try
			{
				if (board[x, y] == Mark.None)
				{
					//Assigns the board cell to the given mark paramater and returns true.
					board[x, y] = mark;
					return true;
				}
				else
				{
					//Return false if the square is already occupied.
					return false;
				}
			}
			catch
			{
				//Returns false if an error would've occurred, this happens when the index is out of range
				return false;
			}
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
			//Nested for loop for searching for empty board cells, uses GetLongLength() to find length of x and y axis
			for (int i = 0; i < board.GetLongLength(0); i++)
			{
				for (int j = 0; j < board.GetLongLength(1); j++)
				{
					if(board[i,j] == Mark.None)
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
			//Here nested for loops are used to search through all combinations of the cells to determine if a player
			//Has won or lost the game, this checks through the y axis.
			for (int horizontal = 0; horizontal < board.GetLongLength(0); horizontal++)
			{
				int inCommon = 1;
				for (int vertical = 1; vertical < board.GetLongLength(1); vertical++)
				{
					//Checks to see if the next board position is equal to the current board position
					if (board[horizontal, vertical] == board[horizontal, vertical - 1])
					{
						inCommon++;
						//In common is used to keep track of the current line of same marks on the board.
						if(inCommon >= numForARow)
						{
							//If the cells in common are player marks, it will return the player's mark
							if(board[horizontal, vertical] != Mark.None)
							{
								return board[horizontal, vertical];
							}
						}
					}
					else
					{
						//Resets the search back to the beginning if a board position does not follow the current pattern.
						inCommon = 1;
					}
				}
			}
			//Checks for any winners along the x axis
			for(int vertical = 0; vertical < board.GetLongLength(1); vertical++)
			{
				int inCommon = 1;
				for (int horizontal = 1; horizontal < board.GetLongLength(0); horizontal++)
				{
					//Checks to see if the next board position is equal to the current board position
					if (board[horizontal, vertical] == board[horizontal - 1, vertical])
					{
						inCommon++;
						//NumForARow is assigned at the start of the program and contains how many elements need to be in a row for a win.
						if (inCommon >= numForARow)
						{
							//If the cells in common are player marks, it will return the player's mark
							if (board[horizontal, vertical] != Mark.None)
							{
								return board[horizontal, vertical];
							}
						}
					}
					else
					{
						//Resets the search back to the beginning if a board position does not follow the current pattern.
						inCommon = 1;
					}
				}
			}

			#region diagonalChecks
			//These two nested for loops check for diagonal wins in both direction, ascending and descending along the grid.
			for (int horizontal = 0; horizontal < board.GetLongLength(0) - 1; horizontal++)
			{
				//Initialising some local variables to keep track of current progression and an increment counter for moving along the board.
				int inCommon = 1;
				int tempHorizontal = horizontal;

				for (int vertical = 0; vertical < board.GetLongLength(1) - 1; vertical++)
				{
					if (tempHorizontal + 1 < board.GetLongLength(0) && vertical + 1 < board.GetLongLength(1))
					{
						if (board[tempHorizontal, vertical] == board[tempHorizontal + 1, vertical + 1])
						{
							inCommon++;
							if (inCommon >= numForARow)
							{
								//If the cells in common are player marks, it will return the player's mark
								if (board[tempHorizontal, vertical] != Mark.None)
								{
									return board[tempHorizontal, vertical];
								}
							}
						}
						else
						{
							inCommon = 1;
						}
						//This if statement limits how high tempHorizontal can go, therefore stopping any out of bounds errors from occuring.
						if (tempHorizontal < board.GetLongLength(0) - 1)
						{
							tempHorizontal++;
						}
					}
				}
			}

			//Similar function to last that instead checks the opposite direction along the board.
			for (int vertical = 0; vertical < board.GetLongLength(1) - 1; vertical++)
			{
				int inCommon = 1;
				int tempVertical = vertical;
				for (int horizontal = 0; horizontal < board.GetLongLength(0) - 1; horizontal++)
				{
					if (tempVertical - 1 > 0 && vertical + 1 < board.GetLongLength(1))
					{
						if (board[horizontal, tempVertical] == board[horizontal + 1, tempVertical - 1])
						{
							inCommon++;
							if (inCommon >= numForARow)
							{
								//If the cells in common are player marks, it will return the player's mark
								if (board[horizontal, tempVertical] != Mark.None)
								{
									return board[horizontal, tempVertical];
								}
							}
						}
						else
						{
							inCommon = 1;
						}
						if (tempVertical < board.GetLongLength(1) - 1)
						{
							tempVertical++;
						}
					}
				}
			}
			#endregion

			//If all of the tests fail, it is likely neither player has won, therefore return Mark.None;
			return Mark.None;
		}

		// Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
		public void PrintBoard()
		{
			string output = "";
			for (int y = 0; y < board.GetLongLength(1); y++)
			{
				if (y > 0)
				{
					Console.WriteLine(output);
				}
				//This else statement is only run on the first iteration of the for loop, as for every other iteration,
				//The above statement is always true.
				else
				{
					//Here I am constructing the string that will be output
					for (int i = 0; i < board.GetLongLength(0) - 1; i++)
					{
						if (i == 0)
						{
							output += "--+";
						}
						if (i == board.GetLongLength(0) - 2)
						{
							output += "--";
						}
						else
						{
							output += "---+";
						}
					}
				}

				//Here I use GetLongLength again to determine how many times the for loop needs to iterate to make the board correctly.
				for (int x = 0; x < board.GetLongLength(0); x++)
				{
					if (x > 0)
					{
						Console.Write(" | ");
					}

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

