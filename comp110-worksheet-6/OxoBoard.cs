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
        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(/* int width = 3, int height = 3, int inARow = 3 */)

        //Define 2D array for board
        Mark[,] board;

        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(int width = 3, int height = 3)
        {
            throw new NotImplementedException("TODO: implement this function and then remove this exception");
            //initialize 3x3 2D char array
            board = new Mark[3, 3];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    board[x, y] = Mark.None;
                }
            }
        }

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y)
        {
            throw new NotImplementedException("TODO: implement this function and then remove this exception");
            return board[x, y];
        }

        // If the specified square is currently empty, fill it with mark and return true.
        // If the square is not empty, leave it as-is and return False.
        public bool SetSquare(int x, int y, Mark mark)
        {
            throw new NotImplementedException("TODO: implement this function and then remove this exception");
            //Check if x and y are within the bounds of the array.
            if ((x >= 0 && y >= 0) && (x < board.Length && y < board.Length))
            {
                if (board[x, y] == Mark.None)
                {
                    board[x, y] = mark;
                    return true;
                }
            }
            //Since the function will stop if it returns something, if we get to this point we can assume that the given parameters weren't valid or the place wasn't empty.
            return false;
        }

        // If there are still empty squares on the board, return false.
        // If there are no empty squares, return true.
        // If there are still empty board on the board, return false.
        // If there are no empty board, return true.
        public bool IsBoardFull()
        {
            throw new NotImplementedException("TODO: implement this function and then remove this exception");
        }
            for (int x = 0; x< 3; x++)
            {
                for (int y = 0; y< 3; y++)
                {
                    if (board[x, y] != Mark.None)
                        continue;
                    return false;
                }
}

            return true;
        }

		// If a player has three in a row, return Mark.O or Mark.X depending on which player.
		// Otherwise, return Mark.None.
		public Mark GetWinner()
        // If a player has three in a row, return Mark.O or Mark.X depending on which player.
        // Otherwise, return Mark.None.
public Mark GetWinner()
{
    throw new NotImplementedException("TODO: implement this function and then remove this exception");
}
            //Check for 3 of the same in each row
            for (var y = 0; y<board.GetLength(0); y++)
            {
                if (GetSquare(0, y) != Mark.None &&
                    board[0, y] == board[1, y] && board[0, y] == board[2, y])
                {
                    return board[0, y];
                }
            }
            //Check for 3 of the same in each diagonal
            if (GetSquare(1, 1) != Mark.None &&
            (board[1, 1] == board[0, 0] && board[1, 1] == board[2, 2] ||
             board[1, 1] == board[2, 0] && board[1, 1] == board[0, 2]))
            {

                return board[1, 1];
            }
            //Check for 3 of the same in each column
            for (var x = 0; x<board.GetLength(0); x++)
            {
                if (GetSquare(x, 0) != Mark.None &&
                    board[x, 0] == board[x, 1] && board[x, 0] == board[x, 2])
                {
                    return board[x, 0];
                }
            }


            return Mark.None;
        }

		// Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
		public void PrintBoard()