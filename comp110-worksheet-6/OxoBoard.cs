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
		Mark[,] boardSpaces = new Mark[3,3]; //Creates a new array using the Mark enumerable
		public int fullSpaces; //creates an int value representing the filled spaces
		List<Mark> occupiedSpacesX = new List<Mark>(); //Two seperate lists made to contain the used spaces for X and O
		List<Mark> occupiedSpacesO = new List<Mark>();

		public OxoBoard()
		{
			boardSpaces.Initialize();
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
			if (Mark.X.Equals(true))
			{
				occupiedSpacesX.Add(GetSquare(x, y)); //Adds the currently occupied space of X to the occupiedSpacesX list
				Mark test = new Mark(); //Sets test to represent Mark
				return test; //Returns test
			}

			else
			{
				occupiedSpacesO.Add(GetSquare(x, y)); //Does the same for O to occupiedSpacesO
				Mark test = new Mark();
				return test;
			}


		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
			if (Mark.None.Equals(true)) //If Mark.None is true, the space is empty, so the code will continue
			{
				boardSpaces[x, y] = mark; //fills the board spaces with mark
				fullSpaces = fullSpaces + 1; //adds 1 to the fullSpaces value
				return true;
			}
			else
				return false;
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
			if (fullSpaces == 9) //if the fullSpaces value is 9, all 9 spaces have been filled, so true is returned
			{
				return true;
			}
			else //if fullSpaces is not equal to 9 then not all spaces have been filled
				return false;
			
		}

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
			for (int length = 0; length < boardSpaces.GetLength(0); length++) //Sets 
			{
				if (occupiedSpacesX.Contains(GetSquare(length, 0)) && occupiedSpacesX.Contains(GetSquare(length, 1)) && occupiedSpacesX.Contains(GetSquare(length, 2)))
				{//Uses the length value to determine the length of the grid
					return Mark.X; //returns Mark.X if each of these values are met
				}
			}

			for (int height = 0; height < boardSpaces.GetLength(0); height++) //the same is done for height
			{
				if (occupiedSpacesX.Contains(GetSquare(0, height)) && occupiedSpacesX.Contains(GetSquare(0, height)) && occupiedSpacesX.Contains(GetSquare(0, height)))
				{
					return Mark.X; ;
				}
			}

			if (occupiedSpacesX.Contains(GetSquare(0, 0)) && occupiedSpacesX.Contains(GetSquare(1, 1)) && occupiedSpacesX.Contains(GetSquare(2, 2))) 
			{
				return Mark.X;
			}

			if (occupiedSpacesX.Contains(GetSquare(0, 2)) && occupiedSpacesX.Contains(GetSquare(1, 1)) && occupiedSpacesX.Contains(GetSquare(0, 2))) 
			{
				return Mark.X;
			}

			for (int length = 0; length < boardSpaces.GetLength(0); length++)
			{
				if (occupiedSpacesO.Contains(GetSquare(length, 0)) && occupiedSpacesO.Contains(GetSquare(length, 1)) && occupiedSpacesO.Contains(GetSquare(length, 2)))
				{
					return Mark.O;
				}
			}

			for (int height = 0; height < boardSpaces.GetLength(0); height++)
			{
				if (occupiedSpacesO.Contains(GetSquare(0, height)) && occupiedSpacesO.Contains(GetSquare(0, height)) && occupiedSpacesO.Contains(GetSquare(0, height)))
				{
					return Mark.O; ;
				}
			}

			if (occupiedSpacesO.Contains(GetSquare(0, 0)) && occupiedSpacesO.Contains(GetSquare(1, 1)) && occupiedSpacesO.Contains(GetSquare(2, 2)))
			{
				return Mark.O;
			}

			if (occupiedSpacesO.Contains(GetSquare(0, 2)) && occupiedSpacesO.Contains(GetSquare(1, 1)) && occupiedSpacesO.Contains(GetSquare(0, 2)))
			{
				return Mark.O;
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

