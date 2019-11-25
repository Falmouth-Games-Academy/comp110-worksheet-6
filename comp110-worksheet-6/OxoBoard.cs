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
        public Mark[,] Board;
        /*I did not hit her, it's not true!
        It's bullshit! I did not hit her!
        I did not!
        Oh hi, Mark*/
        private int inARow;
        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(int width = 3, int height = 3, int inARowToWin = 3)
        {
            inARow = inARowToWin;
            Board = new Mark[width, height];
            for (int y = 0; y < Board.GetLength(1); y++)
            {
                for (int x = 0; x < Board.GetLength(0); x++)
                {
                    Board[x, y] = Mark.None;
                }
            }
        }

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y)
        {
            return Board[x, y];
        }

        // If the specified square is currently empty, fill it with mark and return true.
        // If the square is not empty, leave it as-is and return False.
        public bool SetSquare(int x, int y, Mark mark)
        {
            if (Board[x, y] == Mark.None)
            {
                Board[x, y] = mark;
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
            for (int y = 0; y < Board.GetLength(1); y++)
            {
                for (int x = 0; x < Board.GetLength(0); x++)
                {
                    if (Board[x, y] == Mark.None)
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
            //Double for loop to check horizontal sequences of the same mark
            for (int y = 0; y < Board.GetLength(1); y++)
            {
                for (int x = 0; x <= Board.GetLength(0) - inARow; x++)
                {
                    Mark markToCheck = Board[x, y];
                    bool sequence = true;
                    if (markToCheck != Mark.None)
                    {
                        for (int k = 1; k < inARow; k++)
                        {
                            if (Board[x + k, y] != markToCheck)
                            {
                                sequence = false;
                                break;
                            }
                        }
                        if (sequence)
                        {
                            return markToCheck;
                        }
                    }
                }
            }

            //Double for loop to check vertical sequences of the same mark
            for (int y = 0; y <= Board.GetLength(1) - inARow; y++)
            {
                for (int x = 0; x < Board.GetLength(0); x++)
                {
                    Mark markToCheck = Board[x, y];
                    bool sequence = true;
                    if (markToCheck != Mark.None)
                    {
                        for (int k = 1; k < inARow; k++)
                        {
                            if (Board[x, y + k] != markToCheck)
                            {
                                sequence = false;
                                break;
                            }
                        }
                        if (sequence)
                        {
                            return markToCheck;
                        }
                    }
                }
            }

            //Double for loop to check left-to-right diagonal sequences of the same mark
            for (int y = 0; y <= Board.GetLength(1) - inARow; y++)
            {
                for (int x = 0; x <= Board.GetLength(0) - inARow; x++)
                {
                    Mark markToCheck = Board[x, y];
                    bool sequence = true;
                    if (markToCheck != Mark.None)
                    {
                        for (int k = 1; k < inARow; k++)
                        {
                            if (Board[x + k, y + k] != markToCheck)
                            {
                                sequence = false;
                                break;
                            }
                        }
                        if (sequence)
                        {
                            return markToCheck;
                        }
                    }
                }
            }

            //Double for loop to check right-to-left diagonal sequences of the same mark
            for (int y = 0; y <= Board.GetLength(1) - inARow; y++)
            {
                for (int x = inARow - 1; x < Board.GetLength(0); x++)
                {
                    Mark markToCheck = Board[x, y];
                    bool sequence = true;
                    if (markToCheck != Mark.None)
                    {
                        for (int k = 1; k < inARow; k++)
                        {
                            if (Board[x - k, y + k] != markToCheck)
                            {
                                sequence = false;
                                break;
                            }
                        }
                        if (sequence)
                        {
                            return markToCheck;
                        }
                    }
                }
            }

            /*
            This deserves to stay here as a reminder of what we went through, the horrors that we've seen and the suffering we endured.

            if (Board[0, 0] == Mark.O && Board[0, 1] == Mark.O && Board[0, 2] == Mark.O )
            {
                return Mark.O;
            }
            else if (Board[1, 0] == Mark.O && Board[1, 1] == Mark.O && Board[1, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (Board[2, 0] == Mark.O && Board[2, 1] == Mark.O && Board[2, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (Board[0, 0] == Mark.O && Board[1, 0] == Mark.O && Board[2, 0] == Mark.O)
            {
                return Mark.O;
            }
            else if (Board[0, 1] == Mark.O && Board[1, 1] == Mark.O && Board[2, 1] == Mark.O)
            {
                return Mark.O;
            }
            else if (Board[0, 2] == Mark.O && Board[1, 2] == Mark.O && Board[2, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (Board[0, 0] == Mark.O && Board[1, 1] == Mark.O && Board[2, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (Board[0, 2] == Mark.O && Board[1, 1] == Mark.O && Board[0, 2] == Mark.O)
            {
                return Mark.O;

            }

            if (Board[0, 0] == Mark.X && Board[0, 1] == Mark.X && Board[0, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (Board[1, 0] == Mark.X && Board[1, 1] == Mark.X && Board[1, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (Board[2, 0] == Mark.X && Board[2, 1] == Mark.X && Board[2, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (Board[0, 0] == Mark.X && Board[1, 0] == Mark.X && Board[2, 0] == Mark.X)
            {
                return Mark.X;
            }
            else if (Board[0, 1] == Mark.X && Board[1, 1] == Mark.X && Board[2, 1] == Mark.X)
            {
                return Mark.X;
            }
            else if (Board[0, 2] == Mark.X && Board[1, 2] == Mark.X && Board[2, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (Board[0, 0] == Mark.X && Board[1, 1] == Mark.X && Board[2, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (Board[0, 2] == Mark.X && Board[1, 1] == Mark.X && Board[0, 2] == Mark.X)
            {
                return Mark.X;

            }*/

            return Mark.None;
        }

        // Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
        public void PrintBoard()
        {
            for (int y = 0; y < Board.GetLength(1); y++)
            {
                if (y > 0)
                {
                    Console.Write("--+");
                    for (int i = 0; i < Board.GetLength(0) - 2; i++)
                    {
                        Console.Write("---+");
                    }
                    Console.WriteLine("--");
                }

                for (int x = 0; x < Board.GetLength(0); x++)
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