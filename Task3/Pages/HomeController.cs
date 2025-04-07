using Microsoft.AspNetCore.Mvc;
using Task3.Models;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        private static GameState game = new GameState();

        public IActionResult Index()
        {
            return View(game);
        }

        public IActionResult Move(int row, int col)
        {
            game.MakeMove(row, col);
            return RedirectToAction("Index");
        }

        public IActionResult Reset()
        {
            game = new GameState();
            return RedirectToAction("Index");
        }
    }
}