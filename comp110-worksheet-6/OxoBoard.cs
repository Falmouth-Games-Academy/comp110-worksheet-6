using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6
{
	public enum Mark { None, O, X };

    //
	public class OxoBoard
	{
        //declaring list
        public Mark[,] listMark;

		// Constructor. Perform any necessary data initialisation here.
		// Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
		public OxoBoard(/*int width = 3, int height = 3, int inARow = 3*/)
		{
            //making 2 dimensional arae 3 by 3
            listMark = new Mark[3,3];

            //making an empty 3 by 3 board
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    listMark[x,y] = Mark.None;
                }
            }




		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            //returning the x and y co-ordinates
            return listMark[x, y];


		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            //checking if the x and y co-ordinates are empty them they are equal to mark then true is returned.
            if (listMark[x,y] == Mark.None)
            {
                listMark[x, y] = mark;
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
            //going through the y and x co-ordinates of the 3 by 3 board
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    //if the x and y co-ordinates are empty then false is returned.
                    if (listMark[x,y] == Mark.None)
                    {
                        return false;

                    }
                }
            }

            //otherwise true is returned
            return true;

        }

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
            //checking what co-ordinates are inputed and returning the 0
            if (listMark[0,0] == Mark.O && listMark[1,0] == Mark.O && listMark[2,0] == Mark.O)
            {
                return Mark.O;
            }
            else if (listMark[0, 1] == Mark.O && listMark[1, 1] == Mark.O && listMark[2, 1] == Mark.O)
            {
                return Mark.O;
            }
            else if (listMark[0, 2] == Mark.O && listMark[1, 2] == Mark.O && listMark[2, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (listMark[0, 0] == Mark.O && listMark[0, 1] == Mark.O && listMark[0, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (listMark[1, 0] == Mark.O && listMark[1, 1] == Mark.O && listMark[2, 1] == Mark.O)
            {
                return Mark.O;
            }
            else if (listMark[2, 0] == Mark.O && listMark[2, 1] == Mark.O && listMark[2, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (listMark[0, 0] == Mark.O && listMark[1, 1] == Mark.O && listMark[2, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (listMark[0, 2] == Mark.O && listMark[1, 1] == Mark.O && listMark[2, 0] == Mark.O)
            {
                return Mark.O;
            }
        


            //checking what co-ordinates are inputed and then returning X.
            if (listMark[0, 0] == Mark.X && listMark[1, 0] == Mark.X && listMark[2, 0] == Mark.X)
            {
                return Mark.X;
            }
            else if (listMark[0, 1] == Mark.X && listMark[1, 1] == Mark.X && listMark[2, 1] == Mark.X)
            {
                return Mark.X;
            }
            else if (listMark[0, 2] == Mark.X && listMark[1, 2] == Mark.X && listMark[2, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (listMark[0, 0] == Mark.X && listMark[0, 1] == Mark.X && listMark[0, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (listMark[1, 0] == Mark.X && listMark[1, 1] == Mark.X && listMark[2, 1] == Mark.X)
            {
                return Mark.X;
            }
            else if (listMark[2, 0] == Mark.X && listMark[2, 1] == Mark.X && listMark[2, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (listMark[0, 0] == Mark.X && listMark[1, 1] == Mark.X && listMark[2, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (listMark[0, 2] == Mark.X && listMark[1, 1] == Mark.X && listMark[2, 0] == Mark.X)
            {
                return Mark.X;
            }


            //otherwise none is returned.
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

