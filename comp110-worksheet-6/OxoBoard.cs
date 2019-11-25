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
        private List<List<Mark>> board;

        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(int width = 3, int height = 3, int inARow = 3)
		{
            board = new List<List<Mark>>();
            for (int i = 0; i < height; i++)
            {
                List<Mark> sublist = new List<Mark>();
                for (int j = 0; j < width; j++)
                {
                    sublist.Add(Mark.None);
                }
                board.Add(sublist);
            }
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            try
            {
                return board[x][y];
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return Mark.X;
            }
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            if (GetSquare(x, y) == Mark.None)
            {
                board[x][y] = mark;
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
            bool hasSpace = true;
            foreach (List<Mark> row in board)
            {
                foreach (Mark mark in row)
                {
                    if (mark == Mark.None)
                    {
                        hasSpace = false;
                    }
                }
            }
            return hasSpace;
		}

        private Mark checkLine(List<Mark> line)
        {
            Mark winner = line[0];
            Mark firstMark = line[0];
            foreach (Mark mark in line)
            {
                if ((firstMark == Mark.None) || (mark != firstMark))
                {
                    winner = Mark.None;
                }
            }
            return winner;
        }

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
		{
            Mark winner = Mark.None;

            // Check the Lines of the board.
            foreach (List<Mark> line in board)
            {
                if (winner == Mark.None)
                {
                    winner = checkLine(line);
                }
            }

            
            // Check the Columns of the board.
            for (int i = 0; i < board.Count; i++)
            {
                if (winner == Mark.None)
                {
                    List<Mark> column = new List<Mark>();
                    for (int j = 0; j < board[i].Count; j++)
                    {
                        column.Add(board[i][j]);
                    }
                    winner = checkLine(column);
                }
            }

            if (winner == Mark.None)
            {
                List<Mark> diagonal = new List<Mark>();
                for (int i = 0; i < board.Count; i++)
                {
                    diagonal.Add(board[i][i]);
                }
                winner = checkLine(diagonal);
            }

            if (winner == Mark.None)
            {
                List<Mark> reverseDiagonal = new List<Mark>();
                for (int i = 0; i < board.Count; i++)
                {
                    reverseDiagonal.Add(board[i][board.Count - 1 - i]);
                }
                winner = checkLine(reverseDiagonal);
            }

            return winner;
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

