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
        public Mark[,] board;
        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(/* int width = 3, int height = 3, int inARow = 3 */)
        {
            board = new Mark[3, 3];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = Mark.None;
                }
            }
            //throw new NotImplementedException("TODO: implement this function and then remove this exception");
        }

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y)
        {
            return board[x, y];
        }

        // If the specified square is currently empty, fill it with mark and return true.
        // If the square is not empty, leave it as-is and return False.
        public bool SetSquare(int x, int y, Mark mark)
        {
            if (board[x, y] == Mark.None)
            {
                board[x, y] = mark;
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
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == Mark.None)
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
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != Mark.None) //Only look inside the cell if it's not empty.
                    {
                        int currI = i + 2, currJ = j + 2;
                        int[] currSquare = new int[] { i, j };
                        if (currI < 3 && currJ < 3)
                        {
                            if ((board[i, j] == board[i + 1, j]) && (board[i, j] == board[i + 2, j])) //Checks for a horizontal match on the board
                            {
                                return board[i, j];
                            }
                            else if ((board[i, j] == board[i, j + 1]) && (board[i, j] == board[i, j + 2])) //Checks for a vertical match on the board
                            {
                                return board[i, j];
                            }
                            else if ((board[i, j] == board[i + 1, j + 1]) && (board[i, j] == board[i + 2, j + 2])) //Checks for diagonal match on the board top left
                            {
                                return board[i, j];
                            }
                            else if ((board[0, 2] != Mark.None) && (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])) //Checks for diagonal match on the board top right
                            {
                                return board[0, 2];
                                //Couldn't think of a smarter way to do this, and it should be fine since it's only 2 diagonals in a 3x3 grid.
                            }
                        }
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

