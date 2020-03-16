using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackjackTycoon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BlackjackTycoon.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /* Using "Authorize" you can force the user to login before viewing this page. */
        [Authorize]
        public IActionResult ChooseGame()
        {
            /* Get the current logged in user. */
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(ViewBag.userId).Result;
            ViewBag.User = user;

            /* Creating list of games to loop through and display on "ChooseGame" view. */
            ViewBag.Games = new List<Game>();
            /* 6 games for testing purposes */
            ViewBag.Games.Add(new CoinflipGame());
            ViewBag.Games.Add(new CoinflipGame());
            ViewBag.Games.Add(new CoinflipGame());
            ViewBag.Games.Add(new CoinflipGame());
            ViewBag.Games.Add(new CoinflipGame());
            ViewBag.Games.Add(new CoinflipGame());

            return View();
        }

        public IActionResult GameSetup(Game newGame)
        {
            /* Get the current logged in user. */
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(ViewBag.userId).Result;
            ViewBag.User = user;
            ViewBag.Game = newGame;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
