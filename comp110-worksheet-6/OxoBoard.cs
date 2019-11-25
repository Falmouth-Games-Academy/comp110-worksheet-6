using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6
{
	public enum Mark { None, O, X };
    // Enums used to return what tile is filled with what marker

    
	public class OxoBoard
	{
        public Mark[,] boardArray;
        // Array of Mark Enums set up to represent the board, Array is 2D due to board being 3x3

        // Creating the board and setting each tile as empty
        public OxoBoard()
		{
            boardArray = new Mark[3, 3];
            // 2 For loops used to go through each row and collum of board
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    // Then for each tile of the board it is set as empty
                    boardArray[x, y] = Mark.None;
                }
            }
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            if(boardArray[x, y] != null)
            {
                // Returns what it inside the tile being checked
                return boardArray[x, y];
            }
            else
            {
                // Returns that the tile is empty if cords are outside the board
                return Mark.None;
            }
           
           

        

		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            // If statement that checks if cords are inside the board
            if((x >= 0 && x <= 2) && (y >= 0 && y <= 2))
            {
                if (boardArray[x, y] == Mark.None)
                {
                    boardArray[x, y] = mark;
                    return true;
                    // Returns true if board tile was empty and was now replaced by X or O
                }
                else
                {
                    return false;
                    // Returns flase if tile was already occupied and leaves tile as is
                }
            }
            else
            {
                return false;
                // Returns false as invalid move if player inputted cords that were off the 3x3 grid
            }
          
            

            

		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
            int filledTiles = 0;
            // Int set for amount of tiles that are filled

            // For loops used again to check every tile on the 3x3 grid
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if(boardArray[x , y] == Mark.None)
                    {
                        // Board is empty on this tile
                    }
                    else
                    {
                        filledTiles++;
                        // Board tile is occupied
                    }
                }
            }

            // After checking every tile if all tiles are filled filedTiles will be 9
            if(filledTiles < 9)
            {
                // If there is not 9 filledTiles the board still has spaces
                return false;
            }
            else
            {
                // Else if there is 9 filledTiles then the board is full
                return true;
            }
        }

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{

            // Here I use if statements to check every possible way of winning
            // Quite inefficent but still works for determining every winning outcome on a 3x3 grid

            // X Horizontal
            if(boardArray[0,0] == Mark.X && boardArray[1, 0] == Mark.X && boardArray[2, 0] == Mark.X)
            {
                return Mark.X;
            }
            else if (boardArray[0, 1] == Mark.X && boardArray[1, 1] == Mark.X && boardArray[2, 1] == Mark.X)
            {
                return Mark.X;
            }
            else if (boardArray[0, 2] == Mark.X && boardArray[1, 2] == Mark.X && boardArray[2, 2] == Mark.X)
            {
                return Mark.X;
            }

            // O Horizontal
            else if (boardArray[0, 0] == Mark.O && boardArray[1, 0] == Mark.O && boardArray[2, 0] == Mark.O)
            {
                return Mark.O;
            }
            else if (boardArray[0, 1] == Mark.O && boardArray[1, 1] == Mark.O && boardArray[2, 1] == Mark.O)
            {
                return Mark.O;
            }
            else if (boardArray[0, 2] == Mark.O && boardArray[1, 2] == Mark.O && boardArray[2, 2] == Mark.O)
            {
                return Mark.O;
            }

            // X Vertical

            else if (boardArray[0, 0] == Mark.X && boardArray[0, 1] == Mark.X && boardArray[0, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (boardArray[1, 0] == Mark.X && boardArray[1, 1 ] == Mark.X && boardArray[1, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (boardArray[2, 0] == Mark.X && boardArray[2, 1] == Mark.X && boardArray[2, 2] == Mark.X)
            {
                return Mark.X;
            }

            // O Vertical

            else if (boardArray[0, 0] == Mark.O && boardArray[0, 1] == Mark.O && boardArray[0, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (boardArray[1, 0] == Mark.O && boardArray[1, 1] == Mark.O && boardArray[1, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (boardArray[2, 0] == Mark.O && boardArray[2, 1] == Mark.O && boardArray[2, 2] == Mark.O)
            {
                return Mark.O;
            }

            // X Diagonal

            else if (boardArray[0, 0] == Mark.X && boardArray[1, 1] == Mark.X && boardArray[2, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (boardArray[0, 2] == Mark.X && boardArray[1, 1] == Mark.X && boardArray[2, 0] == Mark.X)
            {
                return Mark.X;
            }
            // O Diagonal

            else if (boardArray[0, 0] == Mark.O && boardArray[1, 1] == Mark.O && boardArray[2, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (boardArray[0, 2] == Mark.O && boardArray[1, 1] == Mark.O && boardArray[2, 0] == Mark.O)
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

