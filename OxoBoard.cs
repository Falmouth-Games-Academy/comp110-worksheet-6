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
        public int width = 3;
        public int height = 3;
        public int inARow = 3;
        int[,] myGrid = new int[width, height];
        public bool isBoardFull;
        public int topLeft;
        public int topMiddle;


        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(/* int width = 3, int height = 3, int inARow = 3 */)
		{
            GetSquare();
            SetSquare();
            IsBoardFull();
            GetWinner();
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            if(x == 0 && y == 0)
            {
                return topLeft;
            }
            else if(x == 1 && y == 0)
            {
                return topMiddle;
            }
            else if (x == 2 && y == 1)
            {
                return middle;
            }
            for (int i = x; i < myGrid.Length; i++)
            {
       

            }
            for (int i = y; i < myGrid.Length; i++)
            {


            }

        }

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            if(x == Mark.none && y == Mark.none)
            {
                x = mark;
                y = mark;
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
			if(myGrid.Length = Mark.X || Mark.O)
            {
                return isBoardFull;
            }
            else
            {
                return isBoardFull = false;
            }
		}

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
            for (int i = Mark.O; i < myGrid.Length; i++)
            {
                if(i > 3)
                {
                    return Mark.O;
                }
                else
                {
                    return Mark.None;
                }
            }           

            for (int i = Mark.X; i < myGrid.Length; i++)
            {
                if (i > 3)
                {
                    return Mark.X;
                }
                else
                {
                    return Mark.None;
                }
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

