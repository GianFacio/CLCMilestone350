using CLCMilestone.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLCMilestone.Controllers
{
    public class GameBoardController : Controller
    {
        static BoardModel board;

        // Gameboard index
        public IActionResult Index()
        {
            BoardModel model = new BoardModel();
            return View("Index", model);
        }

        // Set up gameboard size and difficulty
        public IActionResult SetGameBoard(BoardModel boardSetup)
        {
            ResetBoard(boardSetup.size, boardSetup.difficulty);
            return View("Index", board);
        }

        // Reset gameboard before game started if gameboard or
        // difficulty not right
        private void ResetBoard(int size, int difficulty)
        {
            board = new BoardModel(size);
            board.setupLiveNeighbors(difficulty);
        }

        // New gameboard
        public IActionResult NewBoard(int size, int difficulty)
        {
            ResetBoard(size, difficulty);
            return PartialView("Board", board);
        }

        // Handle button click for cells
        public IActionResult HandleButtonClick(string cell)
        {
            int[] xy = { Convert.ToInt32(cell.Split(',')[0]), Convert.ToInt32(cell.Split(',')[1]) };
            if (!board.grid[xy[0]][xy[1]].flag)
            {
                if (board.grid[xy[0]][xy[1]].live)
                {
                    board.revealAll();
                    return View("GameLost", board);
                }
                board.floodFill(xy[0], xy[1]);
            }
            return PartialView("Board", board);
        }

        // Update the cells
        public IActionResult UpdateBoard(string cell)
        {
            if (!board.gameOver)
            {
                int[] xy = { Convert.ToInt32(cell.Split(',')[0]), Convert.ToInt32(cell.Split(',')[1]) };
                if (!board.grid[xy[0]][xy[1]].flag)
                {
                    if (board.grid[xy[0]][xy[1]].live)
                    {
                        board.revealAll();
                        return PartialView("Board", board);
                    }
                    board.floodFill(xy[0], xy[1]);
                }
            }
            return PartialView("Board", board);
        }

        // Flags to be set down during game
        public IActionResult FlagHandler(string cell)
        {
            if (!board.gameOver)
            {
                int[] xy = { Convert.ToInt32(cell.Split(',')[0]), Convert.ToInt32(cell.Split(',')[1]) };

                board.grid[xy[0]][xy[1]].flag = !board.grid[xy[0]][xy[1]].flag;
            }
            return PartialView("Board", board);
        }

    }
}
