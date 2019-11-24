using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6
{
	public enum Mark { None, O, X };

    public class Grid
    {
        public Mark mark;
        public Tuple<int, int> gridPosition;
        public Tuple<int, int>[] winningPositions;
    }

    public class OxoBoard
	{
        private Mark[,] boardValues;

        private int boardWidth = 3;
        private int boardHeight = 3;

        private int inARow = 3;

        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(int width = 3, int height = 3, int inARow = 3)
		{
            boardValues = new Mark[width, height];

            boardWidth = width;
            boardHeight = height;

            this.inARow = inARow;
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            return boardValues[x, y];
		}

        // If the specified square is currently empty, fill it with mark and return true.
        // If the square is not empty, leave it as-is and return False.
        public bool SetSquare(int x, int y, Mark mark)
		{
            //Used to make sure the player doesn't enter anything too high
            if (x > boardWidth - 1|| y > boardHeight - 1)
            {
                return false;
            }

            if (boardValues[x, y] == Mark.None)
            {
                boardValues[x, y] = mark;
                return true;
            }

            return false;
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
        {
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    if (boardValues[x, y] == Mark.None)
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
            CycleThroughAllPositions();

            //return CheckConsecutiveSquares(positionsToCheck.ToArray());
            return Mark.None;
        }

        //RENAME LATER
        private void CycleThroughAllPositions()
        {
            for (int x = 0; x <= boardValues.GetLength(0); x++)
            {
                for (int y = 0; y <= boardValues.GetLength(1); y++)
                {
                    CheckConsecutiveSquares(new Tuple<int, int>(x, y));
                }
            }
        }

        private Mark CheckConsecutiveSquares(Tuple<int, int> positionToCheck)
        {
            List<Mark> marks = new List<Mark>();

            for (int xOffset = 0; xOffset < inARow; xOffset++)
            {
                for (int yOffset = 0; yOffset < inARow; yOffset++)
                {
                    if (positionToCheck.Item1 + xOffset < boardWidth && positionToCheck.Item2 + yOffset < boardHeight)
                    {
                        marks.Add(GetSquare(positionToCheck.Item1 + xOffset, positionToCheck.Item2 + yOffset));
                        //Console.WriteLine(GetSquare(positionToCheck.Item1 + x, positionToCheck.Item2 + y));
                        Console.WriteLine(CheckMarks(marks.ToArray()) + "\n");
                    }
                }

                marks = new List<Mark>();
            }

            return Mark.None;
        }

        private Mark CheckMarks(Mark[] marks)
        {
            //Checking for a duplicate
            for (int i = 0; i < marks.Length; i++)
            {
                for (int j = 0; j < marks.Length; j++)
                {
                    if (marks[i] != marks[j])
                    {
                        Console.WriteLine(marks[i] + "\n" + marks[j]);
                        return Mark.None;
                    }
                }
            }

            Console.WriteLine(marks.Length);
            return marks[0];
        }

		// Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
		public void PrintBoard()
		{
			for (int y = 0; y < boardHeight; y++)
			{
				if (y > 0)
					Console.WriteLine("--+---+--");

				for (int x = 0; x < boardWidth; x++)
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

