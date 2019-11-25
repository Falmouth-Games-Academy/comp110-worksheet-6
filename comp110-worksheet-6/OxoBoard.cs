using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6 {
    public enum Mark { None, O, X };

    public class OxoBoard {
        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        private Mark[,] boardSize;
        public OxoBoard( int width = 3, int height = 3, int inARow = 3 ) {
            boardSize = new Mark[width, height];
        }

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y) {
            return boardSize[x, y];
        }

        // If the specified square is currently empty, fill it with mark and return true.
        // If the square is not empty, leave it as-is and return False.
        public bool SetSquare(int x, int y, Mark mark) {
            if (boardSize[x, y] == Mark.None) {
                boardSize[x, y] = mark;
                return true;
            }
            else {
                return false;
            }
        }

        // If there are still empty squares on the board, return false.
        // If there are no empty squares, return true.
        public bool IsBoardFull() {
            for (int x = 0; x < boardSize.GetLength(0); x++) {
                for (int y = 0; y < boardSize.GetLength(1); y++) {
                    if (boardSize[x, y] == Mark.None) {
                        return false;
                    }
                }
            }
            return true;
        }

        // If a player has three in a row, return Mark.O or Mark.X depending on which player.
        // Otherwise, return Mark.None.
        public Mark GetWinner() {
            // Check if Horizontal win
            for (int horizontal = 0; horizontal < boardSize.GetLength(0); horizontal++) {
                if (boardSize[horizontal, 0] == boardSize[horizontal, 1] && boardSize[horizontal, 1] == boardSize[horizontal, 2]) {
                    return GetSquare(horizontal, 0);
                }
            }

            // Check if Vertical win
            for (int Vertical = 0; Vertical < boardSize.GetLength(1); Vertical++) {
                if (boardSize[0, Vertical] == boardSize[1, Vertical] && boardSize[1, Vertical] == boardSize[2, Vertical]) {
                    return GetSquare(Vertical, 0);
                }
            }

            // Check if Diagonal win
            if (boardSize[0, 0] == boardSize[1, 1] && boardSize[1, 1] == boardSize[2, 2]) {
                return GetSquare(0, 0);
            }
            else if (boardSize[2, 0] == boardSize[1, 1] && boardSize[1, 1] == boardSize[0, 2]) {
                return GetSquare(2, 0);
            }

            return Mark.None;
        }

        // Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
        public void PrintBoard() {
            for (int y = 0; y < 3; y++) {
                if (y > 0)
                    Console.WriteLine("--+---+--");

                for (int x = 0; x < 3; x++) {
                    if (x > 0)
                        Console.Write(" | ");

                    switch (GetSquare(x, y)) {
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
