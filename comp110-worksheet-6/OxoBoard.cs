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
        int width = 3;
        int height = 3;
        int inARow = 3;
        public int count = 0;
        public Mark[,] Game_Board;
		// Constructor. Perform any necessary data initialisation here.
		// Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
		public OxoBoard()
		{
            Game_Board = new Mark[width, height];

            for (int x = 0; x < width; x++)
            {for (int y = 0; y < height; y++)
                {
                    Game_Board[x, y] = Mark.None;
                    
                }
            }           
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            return Game_Board[x, y];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            if (Game_Board[x, y] == Mark.None)
            {
                Game_Board[x, y] = mark;
                return true;
            }
            else {
                return false;
            } 
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Game_Board[x, y] == Mark.None)
                        return false; 

                }
            }
            return true;
		}

        // If a player has three in a row, return Mark.O or Mark.X depending on which player.
        // Otherwise, return Mark.None.
        public Mark GetWinner()
        {



            // check for X
            // Checks columns

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // New variables so they dont change x,y for current start tile checking
                    int y_check = y;
                    for (count = 1; count <= inARow; count++)
                    {
                        if (y_check >= height)
                        { break; }
                        if (Game_Board[x, y_check] == Mark.X)

                        {
                            if (count == inARow)
                            {
                                return Mark.X;
                            }
                            y_check++;
                        }

                        else break;
                    }

                }
            }

            //Checks rows

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int x_check = x;
                    for (count = 1; count <= inARow; count++)
                    {
                        if (x_check >= width)
                        { break; }
                        if (Game_Board[x_check, y] == Mark.X)
                        {
                            if (count == inARow)
                            {
                                return Mark.X;
                            }
                            x_check++;
                        }

                        else break;
                    }


                }
            }


            //Checks for diagonals
            //Checking for x+ and y+

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int x_check = x;
                    int y_check = y;
                    for (count = 1; count <= inARow; count++)
                    {
                        if (x_check >= width || y_check >= height)
                        { break; }
                        if (Game_Board[x_check, y_check] == Mark.X)
                        {
                            if (count == inARow)
                            {
                                return Mark.X;
                            }
                            x_check++;
                            y_check++;
                        }

                        else break;
                    }

                }
            }

            //Checking for x+ and y-

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int x_check = x;
                    int y_check = y;
                    for (count = 1; count <= inARow; count++)
                    {
                        if (x_check >= width || y_check >= height || y_check < 0)
                        { break; }
                        if (Game_Board[x_check, y_check] == Mark.X)
                        {
                            if (count == inARow)
                            {
                                return Mark.X;
                            }
                            x_check++;
                            y_check--;
                        }

                        else break;
                    }
                }
            }

            //check for O

            // Checks columns

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int y_check = y;
                    for (count = 1; count <= inARow; count++)
                    {
                        if (y_check >= height)
                        { break; }
                        if (Game_Board[x, y_check] == Mark.O)
                        {
                            if (count == inARow)
                            {
                                return Mark.O;
                            }
                            y_check++;
                        }

                        else break;
                    }

                }
            }

            //Checks rows

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int x_check = x;
                    for (count = 1; count <= inARow; count++)
                    {
                        if (x_check >= width)
                        { break; }
                        if (Game_Board[x_check, y] == Mark.O)
                        {
                            if (count == inARow)
                            {
                                return Mark.O;
                            }
                            x_check++;
                        }

                        else break;
                    }


                }
            }


            //Checks for diagonals
            //Checking for x+ and y+

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int x_check = x;
                    int y_check = y;
                    for (count = 1; count <= inARow; count++)
                    {
                        if (x_check >= width || y_check >= height)
                        { break; }
                        if (Game_Board[x_check, y_check] == Mark.O)
                        {
                            if (count == inARow)
                            {
                                return Mark.O;
                            }
                            x_check++;
                            y_check++;
                        }

                        else break;
                    }

                }
            }

            //Checking for x+ and y-

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int x_check = x;
                    int y_check = y;
                    for (count = 1; count <= inARow; count++)
                    {
                        if (x_check >= width || y_check >= height || y_check < 0)
                        { break; }
                        if (Game_Board[x_check, y_check] == Mark.O)
                        {
                            if (count == inARow)
                            {
                                return Mark.O;
                            }
                            x_check++;
                            y_check--;
                        }

                        else break;
                    }

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

