using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace comp110_worksheet_6
{
    public enum Mark { None, O, X };

    public class OxoBoard
    {

        public int width;
        public int height;
        public Regex format = new Regex("^[0-2](,[0-2])+$"); //Regular expression that will only allow coma separated integers (0 to 2) ex. 0,0; 0,1; 1,1; 0,2

        public Mark[,] gameBoard;

        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(/* int width = 3, int height = 3, int inARow = 3 */)
        {
            width = height = 3;
            gameBoard = new Mark[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gameBoard[i, j] = Mark.None;
                }
            }
        }

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y)
        {
            return gameBoard[x, y];
        }

        // If the specified square is currently empty, fill it with mark and return true.
        // If the square is not empty, leave it as-is and return False.
        public bool SetSquare(int x, int y, Mark mark)
        {
            string inputString = x + "," + y;
            if (format.IsMatch(inputString))
            {
                if (gameBoard[x, y] == Mark.None)
                {
                    gameBoard[x, y] = mark;
                    return true;
                }
                else
                {
                    return false;
                }
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
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (gameBoard[i, j] == Mark.None)
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
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (gameBoard[i, j] != Mark.None) //Only look inside the cell if it's not empty.
                    {
                        int currI = i + 2, currJ = j + 2;
                        int[] currSquare = new int[] { i, j };
                        if (currI < 3 && currJ < 3)
                        {
                            if ((gameBoard[i, j] == gameBoard[i + 1, j]) && (gameBoard[i, j] == gameBoard[i + 2, j])) //Checks for a horizontal match on the board
                            {
                                return gameBoard[i, j];
                            }
                            else if ((gameBoard[i, j] == gameBoard[i, j + 1]) && (gameBoard[i, j] == gameBoard[i, j + 2])) //Checks for a vertical match on the board
                            {
                                return gameBoard[i, j];
                            }
                            else if ((gameBoard[i, j] == gameBoard[i + 1, j + 1]) && (gameBoard[i, j] == gameBoard[i + 2, j + 2])) //Checks for diagonal match on the board top left
                            {
                                return gameBoard[i, j];
                            }
                            else if ((gameBoard[0, 2] != Mark.None) && (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[0, 2] == gameBoard[2, 0])) //Checks for diagonal match on the board top right
                            {
                                return gameBoard[0, 2];

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

