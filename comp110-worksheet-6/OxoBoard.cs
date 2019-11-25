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
        {
            int[,] tictacktoe = new int[3, 3];
        }

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y)
        {
            if (tictacktoe[x, y] == Mark.O)
            {
                return Mark.O;

            }
            else if (tictacktoe[x, y] == Mark.X)
            {
                return Mark.X;
            }
            else
            {
                return Mark.None;
            }
            // If the specified square is currently empty, fill it with mark and return true.
            // If the square is not empty, leave it as-is and return False.
            public bool SetSquare(int x, int y, Mark mark)
            {
                if (tictacktoe[x, y] == Mark.None)
                {
                    tictacktoe[x, y] = mark;
                    return true;

                }
                else
                {
                    return false;
                }

                // If there are still empty squares on the board, return false.
                // If there are no empty squares, return true.
                public bool IsBoardFull()
                {
                    for (int y = 0; y < 2; y++)
                    {
                        for (int x = 0; x < 2; x++)
                        {
                            if (board[x, y] == Mark.None)
                            {
                                return false;
                            }
                        }
                    }
                }

                // If a player has three in a row, return Mark.O or Mark.X depending on which player.
                // Otherwise, return Mark.None.
                public Mark GetWinner()
                {
                    if Mark.O == tictacktoe[0, 0]&&Mark.O == tictacktoe[1, 1]&&Mark.O == tictacktoe[2, 2]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit();
                    }
                    else if Mark.O == tictacktoe[1, 0]&&Mark.O == tictacktoe[1, 1]&&Mark.O == tictacktoe[0, 2]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit();
        
                    else if Mark.O == tictacktoe[0, 0]&&Mark.O == tictacktoe[1, 0]&&Mark.O == tictacktoe[2, 0]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit(); 
                    else if Mark.O == tictacktoe[0, 0]&&Mark.O == tictacktoe[0, 1]&&Mark.O == tictacktoe[0, 2]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit(); 
                    else if Mark.O == tictacktoe[1, 0]&&Mark.O == tictacktoe[1, 1]&&Mark.O == tictacktoe[1, 2]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit(); 
                    else if Mark.O == tictacktoe[2, 0]&&Mark.O == tictacktoe[2, 1]&&Mark.O == tictacktoe[2, 2]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit();
                    
                    else if Mark.X == tictacktoe[0, 0]&&Mark.O == tictacktoe[1, 1]&&Mark.O == tictacktoe[2, 2]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit();

                    else if Mark.X == tictacktoe[1, 0]&&Mark.O == tictacktoe[1, 1]&&Mark.O == tictacktoe[0, 2]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit();
        
                    else if Mark.X == tictacktoe[0, 0]&&Mark.O == tictacktoe[1, 0]&&Mark.O == tictacktoe[2, 0]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit(); 
                    else if Mark.X == tictacktoe[0, 0]&&Mark.O == tictacktoe[0, 1] &&Mark.O == tictacktoe [0, 2]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit(); 
                    else if Mark.X == tictacktoe[1, 0]&&Mark.O == tictacktoe[1, 1]&&Mark.O == tictacktoe[1, 2]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit(); 
                    else if Mark.X == tictacktoe[2, 0]&&Mark.O == tictacktoe[2, 1]&&Mark.O == tictacktoe[2, 2]{
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                    Application.Exit();
                    
                   }
              else {
               return Mark.None;
    `         }
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

