using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Worksheet 6 by Adrian Tofan.
//Had to copy the code from my other project that I cloned from the original repo and not from my fork and I couldn't commit it properly because I had no permissions.
//Now this project is cloned from my fork and it should work.


namespace comp110_worksheet_6
{
    public enum Mark { None, O, X };


    public class OxoBoard
    {
        Mark[,] board;
        int width = 3;
        int height = 3;
        int inARow = 3;

        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.

        //Initialize the board with a 2D array and then iterate through each one of its coordinates, marking them as empty/none therefore creating an "empty" board.
        public OxoBoard(int width = 3, int height = 3, int inARow = 3)
        {
            board = new Mark[width, height];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    board[i, j] = Mark.None;
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
            if (board[x, y] == Mark.None && (x>=0 && x<3) && (y>=0 && y<3))
            {
                board[x, y] = mark;
                return true;
            }
            return false;

        }

        // If there are still empty squares on the board, return false.
        // If there are no empty squares, return true.

        //Iterate through each square and check if it is empty. If it it is, the board is not full, therefore return false. Otherwise, return true after finish iterating through each one of them.
        public bool IsBoardFull()
        {


            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    if (board[i, j] == Mark.None)
                        return false;
            return true;



        }

        // If a player has three in a row, return Mark.O or Mark.X depending on which player.
        // Otherwise, return Mark.None.
        public Mark GetWinner()
        {
            //Check for horizontal marks
            for (int i = 0; i < 3; i++)
            {
                if (GetSquare(0, 0) != Mark.None && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return GetSquare(i, 0);

            }

            //Check for vertical marks
            for (int j = 0; j < 3; j++)
            {
                if (GetSquare(0, 0) != Mark.None && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                    return GetSquare(0, j);

            }

            //Check for diagonal marks
            if (GetSquare(0,0)!=Mark.None && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return GetSquare(0, 0);
            if (GetSquare(0, 0) != Mark.None &&  board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return GetSquare(0, 2);


            return Mark.None;
        }




        /*
        public bool isHorizontal(int i, int j)

        {
            int counter = 0;

            for (int y = 0; y < height; y++)
                if (board[i, j] == board[i, y])
                    counter++;

            if (counter == inARow)
                return true;

            return false;


        }


        public bool isVertical(int i, int j)

        {
            int counter = 0;

            for (int y = 0; y < width; y++)
                if (board[i, j] == board[i, y])
                    counter++;

            if (counter == inARow)
                return true;

            return false;


        }

        
        public bool isDiagonal(int i, int j)
        {
            int counter = 0;
            int k = 1;

            for (int y = 1; y <= height + width / 3; y++)
            {
                if (board[i, j] == board[i + k, i + k])
                {
                    counter++;
                    k++;
                }
            }

            if (counter == inARow)
                return true;

            return false;

        }
        */







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

