using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VideoGame.BLL.DTO;
using VideoGame.BLL.Servises;
using VideoGame.DAL.Model;
using VideoGame.WEB.Models;

namespace VideoGame.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDataStore<GameDTO> _gameServise;
        public HomeController(ILogger<HomeController> logger, IDataStore<GameDTO> servise)
        {
            _logger = logger;
            _gameServise = servise;
        }

        public async Task<IActionResult> Index()
        {
            var home = new GameViewModel
            {
                Games = (List<GameDTO>)await _gameServise.GetAll()
            };
            return View(home);
        }

        [HttpGet]
        public async Task<ActionResult> MakeGame(int id)
        {
            GameDTO gameDTO;
            if (id == 0) gameDTO = new GameDTO();
            else gameDTO = await _gameServise.Get(id);
            var game = new EditGameViewModel
            {
                EditGame = gameDTO
            };
            return View(game);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGame(int Id)
        {
            var result = await _gameServise.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(string name, string studio, string genre, int id)
        {
            var gameDto = new GameDTO
            {
                Id = id,
                Name = name,
                Genre = (Genre)Enum.Parse(typeof(Genre), genre),
                Studio = studio
            };
            var result = await _gameServise.CreateOrUpdate(gameDto);
            return RedirectToAction(nameof(Index));
        }
        protected override void Dispose(bool disposing)
        {
            _gameServise.Dispose();
            base.Dispose(disposing);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
