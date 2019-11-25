using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6
{
	public enum Mark { None, O, X };

    /// <summary>
    /// Used to store the mark at the current grid position as well as the position itself.
    /// It also stores all possible combinations of a player win to be checked later. This is so 
    /// I can dynamically increase the size of the the grid
    /// </summary>
    public class Grid
    {
        public Mark mark;
        public Tuple<int, int> gridPosition;
        public List<List<Tuple<int, int>>> winPositions = new List<List<Tuple<int, int>>>();

        /// <summary>
        /// A constructor for the Grid class so I can easily assign variables
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="gridPosition"></param>
        public Grid(Mark mark, Tuple<int, int> gridPosition)
        {
            this.mark = mark;
            this.gridPosition = gridPosition;
        }
    }

    public class OxoBoard
	{
        private Grid[,] grids;
        private int inARow = 3;
        private string horizontalASCII = "--+---+--";

        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.

        /// <summary>
        /// The game constructor which assigns the grid size as well as the amount 
        /// in a row for a player to win.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="inARow"></param>
        public OxoBoard(int width = 3, int height = 3, int inARow = 3)
		{
            grids = new Grid[width, height];
            this.inARow = inARow;

            PopulateGrid();
            horizontalASCII = GetHorizontalString();
		}

        /// <summary>
        /// Populates the multidimensional array storing the grids class
        /// and instantiates a new class and assigns the appropriate variables
        /// </summary>
        private void PopulateGrid()
        {
            for (int x = 0; x < grids.GetLength(0); x++)
            {
                for (int y = 0; y < grids.GetLength(1); y++)
                {
                    grids[x, y] = new Grid(Mark.None, new Tuple<int, int>(x, y));
                    AssignWinningPositions(grids[x, y]);
                }
            }
        }

        /// <summary>
        /// Used to cycle through each Grid's possible combinations and then cycles through
        /// those combinations to see if they all match one specific mark
        /// </summary>
        /// <param name="gridTile"></param>
        /// <returns>
        /// If a combination has been met then it returns the mark that won otherwise it
        /// returns none which states no one has one yet
        /// </returns>
        private Mark CheckGridTile(Grid gridTile)
        {
            List<Mark> marks;

            foreach (var winningPositions in gridTile.winPositions)
            {
                marks = new List<Mark>();
                for (int i = 0; i < winningPositions.Count; i++)
                { 
                    if (winningPositions[i].Item1 < grids.GetLength(0) && winningPositions[i].Item2 < grids.GetLength(1))
                    {
                        marks.Add(GetSquare(winningPositions[i].Item1, winningPositions[i].Item2));
                    }
                    
                }
                
                if (IsAllTheSameMarks(marks.ToArray()) && marks.Count == inARow)
                {
                    Console.WriteLine(marks[0] + " won!");
                    return marks[0];
                }
            }

            return Mark.None;
        }

        /// <summary>
        /// Acts like a duplicate checker for the marks in an array
        /// </summary>
        /// <param name="marks"></param>
        /// <returns>
        /// Returns true if all of the marks are the same, but false if 
        /// there is a duplicate of it, or if any contain none
        /// </returns>
        private bool IsAllTheSameMarks(Mark[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
            {
                for (int j = 0; j < marks.Length; j++)
                {
                    if (marks[i] != marks[j] || marks[j] == Mark.None || marks[i] == Mark.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// This is primarily used for testing and seeing which possible positions will
        /// allow for the player to win
        /// </summary>
        /// <param name="gridTile"></param>
        private void DebugGridTile(Grid gridTile)
        {
            for (int i = 0; i < gridTile.winPositions.Count; i++)
            {
                for (int j = 0; j < gridTile.winPositions[i].Count; j++)
                {
                    Console.WriteLine(gridTile.winPositions[i][j]);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Used to assign the possible combinations that include vertical,
        /// horizontal, diagonal and down diagonal
        /// </summary>
        /// <param name="grid"></param>
        private void AssignWinningPositions(Grid grid)
        {
            grid.winPositions.Add(GetHorizontalSolutions(grid.gridPosition));
            grid.winPositions.Add(GetVerticalSolutions(grid.gridPosition));
            grid.winPositions.Add(GetUpDiagonalSolution(grid.gridPosition));
            grid.winPositions.Add(GetDownDiagonalSolution(grid.gridPosition));
        }

        /// <summary>
        /// Gets all of the combinations possible using a position that is horizontal on the
        /// positive x axis since they cycle through all of the xs, so looking behind it isn't
        /// needed here
        /// </summary>
        /// <param name="gridPos"></param>
        /// <returns>
        /// Returns a list of tuple combinations for the horizontal aspect
        /// </returns>
        private List<Tuple<int, int>> GetHorizontalSolutions(Tuple<int, int> gridPos)
        {
            List<Tuple<int, int>> horizontalSet = new List<Tuple<int, int>>();
            horizontalSet.Add(gridPos);

            for (int xOffset = 1; xOffset < inARow; xOffset++)
            {
                horizontalSet.Add(new Tuple<int, int>(gridPos.Item1 + xOffset, gridPos.Item2));
            }

            return horizontalSet;
        }

        /// <summary>
        /// Gets all of the combinations possible using a position for the vertical axis
        /// and is only on the positive y axis since it is checking all of them and therefore
        /// will never need to look backwards
        /// </summary>
        /// <param name="gridPos"></param>
        /// <returns>
        /// Returns a list of tuple position combinations for the vertical axis
        /// </returns>
        private List<Tuple<int, int>> GetVerticalSolutions(Tuple<int, int> gridPos)
        {
            List<Tuple<int, int>> verticalSet = new List<Tuple<int, int>>();
            verticalSet.Add(gridPos);

            for (int yOffset = 1; yOffset < inARow; yOffset++)
            {
                verticalSet.Add(new Tuple<int, int>(gridPos.Item1, gridPos.Item2 + yOffset));
            }

            return verticalSet;
        }

        /// <summary>
        /// Gets all of the diagonal combinations going up; e.g: (0, 0), (1, 1) (2, 2)...
        /// </summary>
        /// <param name="gridPos"></param>
        /// <remarks>
        /// I had to separate the UpDiagonal and DownDiagonal due to method of getting the 
        /// diagonal coordinates being quite different with no solution that I could see
        /// </remarks>
        /// <returns>
        /// Returns a list of tuple position combinations for the upwards diagonal axis
        /// </returns>
        private List<Tuple<int, int>> GetUpDiagonalSolution(Tuple<int, int> gridPos)
        {
            List<Tuple<int, int>> upDiagonalSet = new List<Tuple<int, int>>();

            for (int zOffset = 0; zOffset < inARow; zOffset++)
            {
                upDiagonalSet.Add(new Tuple<int, int>(gridPos.Item1 + zOffset, gridPos.Item2 + zOffset));
            }

            return upDiagonalSet;
        }

        /// <summary>
        /// Gets all of the digonal combinations going downwards; e.g: (0, 2), (1, 1), (2,0)...
        /// </summary>
        /// <param name="gridPos"></param>
        /// <remarks>
        /// I had to separate the UpDiagonal and DownDiagonal due to method of getting the 
        /// diagonal coordinates being quite different with no solution that I could see
        /// </remarks>
        /// <returns>
        /// Returns a list of tuple position combinations for the downwards diagonal axis
        /// </returns>
        private List<Tuple<int, int>> GetDownDiagonalSolution(Tuple<int, int> gridPos)
        {
            List<Tuple<int, int>> downDiagonal = new List<Tuple<int, int>>();

            int y = 0;
            for (int x = 0; x < inARow; x++)
            {
                downDiagonal.Add(new Tuple<int, int>(gridPos.Item1 - x, gridPos.Item2 + y));
                y++;
            }

            return downDiagonal;
        }

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y)
		{
            if (x > grids.GetLength(0) - 1 || y > grids.GetLength(1) - 1 || y < 0 || x < 0)
            {
                return Mark.None;
            }

            return grids[x, y].mark;
		}

        // If the specified square is currently empty, fill it with mark and return true.
        // If the square is not empty, leave it as-is and return False.
        public bool SetSquare(int x, int y, Mark mark)
		{
            //Used to make sure the player doesn't enter anything too high, or too low below 0
            if (x > grids.GetLength(0) - 1|| y > grids.GetLength(1) - 1 || y < 0 || x < 0)
            {
                return false;
            }

            if (grids[x, y].mark == Mark.None)
            {
                grids[x, y].mark = mark;

                grids[x, y].mark = mark;
                grids[x, y].gridPosition = new Tuple<int, int>(x, y);

                return true;
            }

            return false;
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
        {
            for (int x = 0; x < grids.GetLength(0); x++)
            {
                for (int y = 0; y < grids.GetLength(1); y++)
                {
                    if (grids[x, y].mark == Mark.None)
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
            for (int x = 0; x < grids.GetLength(0); x++)
            {
                for (int y = 0; y < grids.GetLength(1); y++)
                {
                    Mark winnerMark = CheckGridTile(grids[x, y]);
                    if (winnerMark != Mark.None)
                    {
                        return winnerMark;
                    }
                }
            }

            return Mark.None;
        }

        //Display the current board state in the terminal.You should only need to edit this if you are attempting the stretch goal.
        /// <summary>
        /// Generates the board and will now scale with the width and height
        /// </summary>
        public void PrintBoard()
        {
            for (int y = 0; y < grids.GetLength(1); y++)
            {
                if (y > 0)
                    Console.WriteLine(horizontalASCII);

                for (int x = 0; x < grids.GetLength(0); x++)
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

        private string GetHorizontalString()
        {
            string twoHorizontal = "--";
            string threeHorizontal = "---";

            string combinedString = "";

            for (int i = 0; i < inARow + 2; i++)
            {
                if (i == 0 || i == inARow + 1)
                {
                    combinedString += twoHorizontal;
                    if (i == 0)
                    {
                        combinedString += "+";
                    }
                    continue;
                }

                combinedString += threeHorizontal;
                combinedString += "+";
            }

            return combinedString;
        }
    }
}

