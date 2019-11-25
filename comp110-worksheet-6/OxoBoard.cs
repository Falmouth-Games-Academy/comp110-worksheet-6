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
        private Mark[] gameboard;

		// Constructor. Perform any necessary data initialisation here.
		// Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
		public OxoBoard(/* int width = 3, int height = 3, int inARow = 3 */)
		{
            //throw new NotImplementedException("TODO: implement this function and then remove this exception");
            gameboard = new Mark[9];
		}

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y)
        {
            //throw new NotImplementedException("TODO: implement this function and then remove this exception");
            return gameboard[y * 3 + x];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            //throw new NotImplementedException("TODO: implement this function and then remove this exception");
            int square = y * 3 + x;

            if (gameboard[square] == Mark.None)
            {
                gameboard[square] = mark;
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
            //throw new NotImplementedException("TODO: implement this function and then remove this exception");
            return !gameboard.Contains(Mark.None);
		}

        private Mark CheckLine(int start, int row)
        {
            var line = gameboard[start];
            return (gameboard[start + row] == line && gameboard[start + 2 * row] == line) ? line : Mark.None; 
        }

        private IEnumerable<Mark> CheckLines()
        {
            for(int i = 0; i < 3; i++)
            {
                yield return CheckLine(i * 3, 1);
                yield return CheckLine(i, 3);
            }

            yield return CheckLine(0, 3 + 1);
            yield return CheckLine(2, 3 - 1);

        }



		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
            //throw new NotImplementedException("TODO: implement this function and then remove this exception");
            foreach (var line in CheckLines())
                if (line != Mark.None)
                    return line;
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

