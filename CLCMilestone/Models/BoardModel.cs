using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CLCMilestone.Models
{
    public class BoardModel
    {
		public string id { get; set; }
        [DisplayName("Size of board")]
        [Required]
		[Range(4, 20, ErrorMessage = "Size range must be from 4 to 20")]
		public int size { get; set; }
        [DisplayName("Difficulty of game")]
        [Required]
		[Range(0, 20, ErrorMessage = "The difficulty range must be from 0 to 20")]
		public int difficulty { get; set; }
		public CellModel[][] grid { get; set; }
		public bool gameOver { get; set; }

		public BoardModel(int s)
		{
			size = s;
			grid = new CellModel[size][];
			for(int i = 0; i < size; i++)
            {
				grid[i] = new CellModel[size];
            }
			gameOver = false;
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					grid[i][j] = new CellModel(i, j, 0, false, false, false);
		}

		// Original minesweeper
        public BoardModel(int size, int difficulty, CellModel[][] grid, bool gameOver)
        {
			this.size = size;
            this.difficulty = difficulty;
            this.grid = grid;
            this.gameOver = gameOver;
        }

		// Setting how many bombs will be in depending on difficulty
        public void setupLiveNeighbors(int diff)
		{
			difficulty = diff;
			int bombCount = 2;
			if (difficulty < 5)
				bombCount += difficulty;
			else if (difficulty < 8)
				bombCount += difficulty + 2;
			else if (difficulty >= 8)
				bombCount += difficulty * 3;
			if (bombCount > size * size) bombCount = size * size / 2;

			Random r1 = new Random(), r2 = new Random(r1.Next());

			while (bombCount > 0)
			{
				int n1 = r1.Next(size), n2 = r2.Next(size);
				if (!grid[n1][n2].live)
				{
					grid[n1][n2].live = true;
					bombCount -= 1;
				}
			}

			calculateLiveNeighbors();
		}

		// Calculate live bombs
		public void calculateLiveNeighbors()
		{
			foreach (var cells in grid)
			{
				foreach(var cell in cells)
                {
					int neighbors = 0;
					if (cell.live)
						neighbors = 9;
					else
						for (int i = -1; i < 2; i++)
							for (int j = -1; j < 2; j++)
								if ((0 <= cell.row + i && cell.row + i < size) && (0 <= cell.column + j && cell.column + j < size))
									if (grid[cell.row + i][cell.column + j].live)
										neighbors += 1;
					cell.neighbors = neighbors;
				}
			}
		}

		// Flood fill with grid row and column
		public void floodFill(int row, int column)
		{
			if (row >= 0 && row < size && column >= 0 && column < size)
			{
				if (grid[row][column].neighbors > 0 && !grid[row][column].live)
					grid[row][column].visited = true;
				else if (grid[row][column].neighbors == 0 && !grid[row][column].visited)
				{
					grid[row][column].visited = true;
					for (int i = -1; i < 2; i++)
						for (int j = -1; j < 2; j++)
							floodFill(row + i, column + j);
				}
			}
		}

		// View all cells
		public void revealAll()
        {
			gameOver = true;
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					grid[i][j].visited = true;
		}

		// Won the game
		public bool hasWon()
        {
			for (int i = 0; i < size; i++)
            {
				for (int j = 0; j < size; j++)
                {
					if ((!grid[i][j].visited && !grid[i][j].live) || (grid[i][j].visited && grid[i][j].live))
                    {
						return false;
                    }
                }
            }
			gameOver = true;
			return true;
        }
        public BoardModel()
        {
        }
    }
}
