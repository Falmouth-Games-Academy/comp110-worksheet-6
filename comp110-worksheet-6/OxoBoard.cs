using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6
{
	public enum Mark 
	{ 
		None, 
		O, 
		X 
	};

	public class OxoBoard
	{
		// Constructor. Perform any necessary data initialisation here.
		// Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.

		private Mark[,] board;
        private int itemsInARow;

		public OxoBoard(int width = 3, int height = 3, int inARow = 3)
        {
			// Initialises game board to a 3 * 3 square
			board = new Mark[width, height];
            itemsInARow = inARow;
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
			// Returns the boards value, if the value is null then it returns Mark.None
			return board[x, y];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
			if (board[x, y] == Mark.None)
			{
				board[x, y] = mark;
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
			for (int x = 0; x < board.GetLength(0); x++)
			{
				for (int y = 0; y < board.GetLength(1); y++)
				{
					if (board[x, y] == Mark.None) 
					{
						return false;
					}
				}
			}

			return true;
		}

        private bool CheckDiagonals(int x, int y)
        {
            bool checkLeft = true;
            bool checkRight = true;
            bool winCondition = false;
            // Check down and right diagonals.
            // Only need to check downwards diagonals to still check every possibility.
            int testX = x;
            int testY = y;
            testX++;
            testY++;
            if (testX < board.GetLength(0) && testY < board.GetLength(1))
            {
                if (board[testX, testY] == Mark.O)
                {
                    int symbolCount = 2;
                    do
                    {
                        testX++;
                        testY++;
                        if (testX < board.GetLength(0) && testY < board.GetLength(1))
                        {
                            if (board[testX, testY] == Mark.O)
                            {
                                symbolCount++;
                            } 
                            else
                            {
                                checkRight = false;
                            }

                            if (symbolCount == itemsInARow)
                            {
                                winCondition = true;
                            }
                        }
                        else
                        {
                            checkRight = false;
                        }

                    } while (checkRight && !winCondition);
                }
            }
            

            // If that was a win we don't need to check down and left diagonals so return the win.
            if (winCondition)
            {
                return winCondition;
            }

            // Otherwise we check the down and left diagonals.
            testX = x--;
            testY = y++;

            if (testX > 0 && testY < board.GetLength(1))
            {
                if (board[testX, testY] == Mark.O)
                {
                    int symbolCount = 2;
                    do
                    {
                        testX--;
                        testY++;
                        if (testX > 0 && testY < board.GetLength(1))
                        {
                            if (board[testX, testY] == Mark.O)
                            {
                                symbolCount++;
                            } else
                            {
                                checkLeft = false;
                            }

                            if (symbolCount == itemsInARow)
                            {
                                winCondition = true;
                            }
                        }
                        else
                        {
                            checkLeft = false;
                        }

                    } while (checkLeft && !winCondition);
                }
            }               

            return winCondition;
        }

		// If a player has x in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
            int playerOCount;
			int playerXCount;

			// Checks the board horizontally for x in a row
			for (int x = 0; x < board.GetLength(0); x++)
			{
                playerXCount = 0;
                playerOCount = 0;
                for (int y = 0; y < board.GetLength(1); y++)
				{
					if (board[x, y] == Mark.O)
					{
						playerOCount++;
					}
					else if (board[x, y] == Mark.X)
					{
						playerXCount++;
					}

					if (playerOCount == itemsInARow)
					{
						return Mark.O;
					} 
					else if (playerXCount == itemsInARow)
					{
						return Mark.X;
					}
				}
			}

			playerXCount = 0;
			playerOCount = 0;

			// Checks the board vertically for x in a row
			for (int y = 0; y < board.GetLength(0); y++)
			{
                playerXCount = 0;
                playerOCount = 0;
                for (int x = 0; x < board.GetLength(1); x++)
				{
					if (board[x, y] == Mark.O)
					{
						playerOCount++;
					}
					else if (board[x, y] == Mark.X)
					{
						playerXCount++;
					}

					if (playerOCount == itemsInARow)
					{
						return Mark.O;
					} 
					else if (playerXCount == itemsInARow)
					{
						return Mark.X;
					}
				}
			}

            playerXCount = 0;
            playerOCount = 0;
            // Checks for diagonals.
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] == Mark.O)
                    {
                        if (CheckDiagonals(x, y))
                        {
                            return Mark.O;
                        }
                    }

                    if (board[x, y] == Mark.X)
                    {
                        if (CheckDiagonals(x, y))
                        {
                            return Mark.X;
                        }
                    }
                }
            }

			return Mark.None;
		}

		// Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
		public void PrintBoard()
		{
			for (int y = 0; y < board.GetLength(0); y++)
			{
				if (y > 0)
					Console.WriteLine("--+---+--");

				for (int x = 0; x < board.GetLength(1); x++)
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