using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6
{
	class Program
	{
		// Read square coordinates from standard input in the form x,y. Return null on error.
		static Tuple<int, int> InputSquare()
		{
			// Get input from console
			string input = Console.ReadLine();

			// Split by comma
			var splitString = input.Split(',');

			// There should be exactly one comma -- if not then error
			if (splitString.Length != 2)
			{
				Console.WriteLine("Invalid input!");
				return null;
			}

			// Try parsing the two parts as ints -- error if either of them fails
			if (!int.TryParse(splitString[0], out int x) || !int.TryParse(splitString[1], out int y))
			{
				Console.WriteLine("Invalid input!");
				return null;
			}

			// No errors, so return the coordinates
			return new Tuple<int, int>(x, y);
		}

		static void Main(string[] args)
		{
			bool gameIsOver = false;
			Mark currentPlayer = Mark.O;

            Tuple<int, int> boardSize = null;
            while (boardSize == null)
            {
                Console.WriteLine("Enter the size of the square in the form x,y:");
                boardSize = InputSquare();
            }
            int inARow = 0;
            while (inARow == 0)
            {
                Console.WriteLine("Enter amount of symbols in a row to win:");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out inARow))
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (inARow == 0 || (inARow > boardSize.Item1 && inARow > boardSize.Item2))
                {
                    Console.WriteLine("Invalid input!");
                    inARow = 0;
                }
            }

            OxoBoard board = new OxoBoard(boardSize.Item1, boardSize.Item2, inARow);

			while (!gameIsOver)
			{
				// Print board
				Console.WriteLine();
				board.PrintBoard();
				Console.WriteLine("Player turn: {0}", currentPlayer);

				// Read input
				Tuple<int, int> square = null;
				while (square == null)
				{
					Console.WriteLine("Enter a square in the form x,y:");
					square = InputSquare();
				}
				
				// Try to play the move
				if (board.SetSquare(square.Item1, square.Item2, currentPlayer))
				{
					// Success, so switch players
					currentPlayer = (currentPlayer == Mark.O) ? Mark.X : Mark.O;

					// Check for a win
					var winner = board.GetWinner();
					if (winner != Mark.None)
					{
						board.PrintBoard();
						Console.WriteLine("Player {0} wins!", winner);
						gameIsOver = true;
					}

					// Check for board full
					if (board.IsBoardFull())
					{
						board.PrintBoard();
						Console.WriteLine("It's a draw!");
						gameIsOver = true;
					}
				}
				else
				{
					Console.WriteLine("Invalid move!");
				}
			}

			Console.WriteLine("Press enter to continue");
			Console.ReadLine();
		}
	}
}
