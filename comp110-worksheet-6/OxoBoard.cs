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
        public Mark[,] gameBoard;

        /// <summary>
        /// Using the height and width parameters to create the new board size.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="inARow"></param>
        public OxoBoard(int width = 3, int height = 3, int inARow = 3)
		{
            gameBoard = new Mark[width, height];
		}

		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            //getting the square that the player is inputing.
            return gameBoard[x, y];
        }

        /// <summary>
        ///  If the specified square is currently empty, fill it with mark and return true
        ///  If the square is not empty, leave it as-is and return False.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        public bool SetSquare(int x, int y, Mark mark)
		{	

            if(gameBoard[x,y] == Mark.None)
            {
                gameBoard[x, y] = mark;
                return true;
            }
            return false;
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
            for (int x = 0; x < gameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < gameBoard.GetLength(1); y++)
                {
                    if(gameBoard[x,y] == Mark.None)
                    {
                        return false;
                    }
                }
            }
            return true;
		}

		/// <summary>
        /// Comparing all the filled spaces to eachother to check if there is a three in a row of any kind.
        /// If there is then it will return the starting tile to select the winner, if there is no winner then
        /// it will mark none.
        /// </summary>
        /// <returns></returns>
		public Mark GetWinner()
		{
            if(gameBoard[0,0] == gameBoard[1,0] && gameBoard[0,0] == gameBoard[2,0])
            {
                return gameBoard[0, 0];
            }
            
            else if (gameBoard[0, 1] == gameBoard[1, 1] && gameBoard[0, 1] == gameBoard[2, 1])
            {
                return gameBoard[0, 1];
            }

            else if (gameBoard[0, 2] == gameBoard[1, 2] && gameBoard[0, 2] == gameBoard[2, 2])
            {
                return gameBoard[0, 2];
            }

            else if (gameBoard[0, 0] == gameBoard[0, 1] && gameBoard[0, 0] == gameBoard[0, 2])
            {
                return gameBoard[0, 0];
            }

            else if (gameBoard[1, 0] == gameBoard[1, 1] && gameBoard[1, 0] == gameBoard[1, 2])
            {
                return gameBoard[1, 0];
            }

            else if (gameBoard[2, 0] == gameBoard[2, 1] && gameBoard[2, 0] == gameBoard[2, 2])
            {
                return gameBoard[2, 0];
            }

            else if (gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[0, 0] == gameBoard[2, 2])
            {
                return gameBoard[0, 0];
            }

            else if (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[2, 0] == gameBoard[2, 0])
            {
                return gameBoard[0, 2];
            }

            else
            {
                return Mark.None;
            }
        }
        
    
        /// <summary>
        /// using the x and y set this prints out the board into the console.
        /// </summary>
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

