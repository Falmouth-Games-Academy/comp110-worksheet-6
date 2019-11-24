using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6
{
	public enum Mark { None, O, X };

    public class Grid
    {
        public Mark mark;
        public Tuple<int, int> gridPosition;
        //I'm so sorry for this nested monstrosity
        public List<List<Tuple<int, int>>> winningPositions = new List<List<Tuple<int, int>>>();

        public Grid(Mark mark, Tuple<int, int> gridPosition)
        {
            this.mark = mark;
            this.gridPosition = gridPosition;
        }
    }

    public class OxoBoard
	{
        private Grid[,] grids;

        private int boardWidth = 3;
        private int boardHeight = 3;

        private int inARow = 3;

        // Constructor. Perform any necessary data initialisation here.
        // Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
        public OxoBoard(int width = 4, int height = 4, int inARow = 3)
		{
            grids = new Grid[width, height];

            boardWidth = width;
            boardHeight = height;

            this.inARow = inARow;

            InstantiateGrids();
		}

        private void InstantiateGrids()
        {
            for (int x = 0; x < grids.GetLength(0); x++)
            {
                for (int y = 0; y < grids.GetLength(1); y++)
                {
                    grids[x, y] = new Grid(Mark.None, new Tuple<int, int>(x, y));
                    AssignWinningPositions(grids[x, y]);
                }
            }

            DebugGridTile(grids[2, 0]);
            DebugGridTile(grids[0, 2]);
        }

        private Mark CheckGridTile(Grid gridTile)
        {
            List<Mark> marks;

            foreach (var winningPositions in gridTile.winningPositions)
            {
                marks = new List<Mark>();
                for (int i = 0; i < winningPositions.Count; i++)
                { 
                    if (winningPositions[i].Item1 < grids.GetLength(0) && winningPositions[i].Item2 < grids.GetLength(1))
                    {
                        marks.Add(GetSquare(winningPositions[i].Item1, winningPositions[i].Item2));
                        //Console.WriteLine(GetSquare(winningPositions[i].Item1, winningPositions[i].Item2));
                    }
                    
                }
                
                if (AllMarksTheSame(marks.ToArray()) && marks.Count == inARow)
                {
                    Console.WriteLine(marks[0] + " won!");
                    return marks[0];
                }

                //Console.WriteLine();
            }

            return Mark.None;
        }

        private bool AllMarksTheSame(Mark[] marks)
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

        private void DebugGridTile(Grid gridTile)
        {
            for (int i = 0; i < gridTile.winningPositions.Count; i++)
            {
                for (int j = 0; j < gridTile.winningPositions[i].Count; j++)
                {
                    Console.WriteLine(gridTile.winningPositions[i][j]);
                }

                Console.WriteLine();
            }
        }

        private void AssignWinningPositions(Grid grid)
        {
            grid.winningPositions.Add(GetHorizontalSolutions(grid.gridPosition));
            grid.winningPositions.Add(GetVerticalSolutions(grid.gridPosition));
            grid.winningPositions.Add(GetUpDiagonalSolution(grid.gridPosition));
            grid.winningPositions.Add(GetDownDiagonalSolution(grid.gridPosition));
        }

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

        private List<Tuple<int, int>> GetUpDiagonalSolution(Tuple<int, int> gridPos)
        {
            List<Tuple<int, int>> upDiagonalSet = new List<Tuple<int, int>>();

            for (int zOffset = 0; zOffset < inARow; zOffset++)
            {
                upDiagonalSet.Add(new Tuple<int, int>(gridPos.Item1 + zOffset, gridPos.Item2 + zOffset));
            }

            return upDiagonalSet;
        }

        private List<Tuple<int, int>> GetDownDiagonalSolution(Tuple<int, int> gridPos)
        {
            List<Tuple<int, int>> downDiagonal = new List<Tuple<int, int>>();

            //int y = inARow - 1;
            //for (int x = 0; x < inARow; x++)
            //{
            //    downDiagonal.Add(new Tuple<int, int>(gridPos.Item1 + x, gridPos.Item2 + y));
            //    y--;
            //}

            int y = 0;
            for (int x = 0; x < inARow; x++)
            {
                //downDiagonal.Add(new Tuple<int, int>(inARow - (gridPos.Item1 - x), inARow - (gridPos.Item2 - y)));
                downDiagonal.Add(new Tuple<int, int>(gridPos.Item1 - x, gridPos.Item2 + y));
                y++;
            }

            //int y = inARow - 1;
            //for (int x = inARow - 1; x >= 0; x--)
            //{
            //    downDiagonal.Add(new Tuple<int, int>(gridPos.Item1 - x - y, gridPos.Item2 + y));
            //    y--;
            //}

            return downDiagonal;
        }

        // Return the contents of the specified square.
        public Mark GetSquare(int x, int y)
		{
            if (x > boardWidth - 1 || y > boardHeight - 1 || y < 0 || x < 0)
            {
                return Mark.None;
            }

            return grids[x, y].mark;
		}

        // If the specified square is currently empty, fill it with mark and return true.
        // If the square is not empty, leave it as-is and return False.
        public bool SetSquare(int x, int y, Mark mark)
		{
            //Used to make sure the player doesn't enter anything too high
            if (x > boardWidth - 1|| y > boardHeight - 1 || y < 0 || x < 0)
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
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
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
            //DebugGridTile(grids[1, 0]);
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

        private Mark CheckMarks(Mark[] marks)
        {
            //Checking for a duplicate
            for (int i = 0; i < marks.Length; i++)
            {
                for (int j = 0; j < marks.Length; j++)
                {
                    if (marks[i] != marks[j])
                    {
                        Console.WriteLine(marks[i] + "\n" + marks[j]);
                        return Mark.None;
                    }
                }
            }

            Console.WriteLine(marks.Length);
            return marks[0];
        }

		// Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
		public void PrintBoard()
		{
			for (int y = 0; y < boardHeight; y++)
			{
				if (y > 0)
					Console.WriteLine("--+---+--");

				for (int x = 0; x < boardWidth; x++)
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

