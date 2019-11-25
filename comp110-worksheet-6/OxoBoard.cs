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
        private Mark[,] tictacktoe; // declare a field, which is accessible from everywhere inside OxoBoard

        public OxoBoard()
        {
            tictacktoe = new Mark[3, 3]; // initialize that field in the constructor
        }

        // Return the contents of the specified square.
        /*
        public Mark GetSquare(int x, int y)
        {
            if (tictacktoe[x, y] == Mark.O) // comparing int and enum - ERROR
            {
                return Mark.O;
            }
            else if (tictacktoe[x, y] == Mark.X) // comparing int and enum - ERROR
            {
                return Mark.X;
            }
            else
            {
                return Mark.None;
            }
        }
        */

        // you can rewrite this function simply like this
        public Mark GetSquare(int x, int y)
        {
            return (Mark)tictacktoe[x, y]; // with an explicit cast
        }

        public bool SetSquare(int x, int y, Mark mark)
        {
            tictacktoe[x, y] = mark; // with an explicit cast

            return false;
        }

        // If there are still empty squares on the board, return false.
        // If there are no empty squares, return true.
        public bool IsBoardFull()
                {
                    for (int y = 0; y < 2; y++)
                    {
                        for (int x = 0; x < 2; x++)
                        {
                            if (tictacktoe[x, y] == Mark.None)
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
                    Mark GetWinner(Mark player)
                    {
                         // check rows
                        if (tictacktoe[0, 0] == player && tictacktoe[0, 1] == player && tictacktoe[0, 2] == player) { return true; }
                        if (tictacktoe[1, 0] == player && tictacktoe[1, 1] == player && tictacktoe[1, 2] == player) { return true; }
                        if (tictacktoe[2, 0] == player && tictacktoe[2, 1] == player && tictacktoe[2, 2] == player) { return true; }

                        // check columns
                        if (tictacktoe[0, 0] == player && tictacktoe[1, 0] == player && tictacktoe[2, 0] == player) { return true; }
                        if (tictacktoe[0, 1] == player && tictacktoe[1, 1] == player && tictacktoe[2, 1] == player) { return true; }
                        if (tictacktoe[0, 2] == player && tictacktoe[1, 2] == player && tictacktoe[2, 2] == player) { return true; }

                        // check diags
                        if (tictacktoe[0, 0] == player && tictacktoe[1, 1] == player && tictacktoe[2, 2] == player) { return true; }
                        if (tictacktoe[0, 2] == player && tictacktoe[1, 1] == player && tictacktoe[2, 0] == player) { return true; }

                        return false;
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

