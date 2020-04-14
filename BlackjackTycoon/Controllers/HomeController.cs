using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackjackTycoon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

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

		public IActionResult About()
		{
			ViewData["Message"] = "About the games.";

			return View();
		}

		public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /* Using "Authorize" you can force the user to login before viewing this page. */
        [Authorize]
        public IActionResult GameSetup()
        {
            /* Get the current logged in user. */
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(ViewBag.userId).Result;
            ViewBag.User = user;

            /* Creating list of games to loop through and display on "ChooseGame" view. */
            ViewBag.Games = new List<Game>();
            ViewBag.Games.Add(new CoinflipGame());
            ViewBag.Games.Add(new BlackjackGame());
            ViewBag.Games.Add(new PokerGame());

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

        // You must be logged in to get a loan from the bank.
        [Authorize]
        public IActionResult Bank()
        {
            /* Get the current logged in user. */
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(ViewBag.userId).Result;
            ViewBag.User = user;

            // Create a bank that the user goes to
            ViewBag.Bank = new Bank("The Rich People's Bank of Richness");
            return View();
        }
        
        public IActionResult Borrow()
        {
            // This is where we make changes in the database...
            // We need to add money to the user's bankroll
            // We need to add money to the user's total borrowed (keeping track of how much they've borrowed)
            return View("Index");
        }
    }
}
