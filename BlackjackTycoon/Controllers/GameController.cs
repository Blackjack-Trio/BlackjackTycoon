using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackjackTycoon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlackjackTycoon.Controllers
{
    public class GameController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public GameController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> PlayCoinflipAsync(string selection, string bet)
        {
            /* Get the current logged in user. */
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(ViewBag.userId).Result;
            ViewBag.User = user;

            /* validation */
            ViewBag.Errors = new List<string>();

            // checks the user selected heads or tails
            if (selection == null) ViewBag.Errors.Add("Please select heads or tails.");
            // checks if bet is an integer
            if (!int.TryParse(bet, out int i)) ViewBag.Errors.Add("The bet must be an integer.");
            // make sure the user has enough money to cover the bet
            if (i > user.Bankroll) ViewBag.Errors.Add("You don't have enough money to place that bet.");
            // bet must be greater than 0
            if (i < 0) ViewBag.Errors.Add("You must bet more than $0");
            /* If any errors got added to error list we'll return the view now */
            if (ViewBag.Errors.Count >= 1) return View("Coinflip");

            // play coinflip
            CoinflipGame coinflip = new CoinflipGame();
            coinflip.Player = user;

            if (coinflip.Play(selection, i)) // i = players bet (i comes from the int.TryParse() method used in validation).
            {
                ViewBag.GameResults = "Winner! You won $" + (int.Parse(bet) * 2);
                ViewBag.LastGame = true;
            }
            else
            {
                ViewBag.GameResults = "Loser! You lost $" + int.Parse(bet);
                ViewBag.LastGame = false;
            }

            // update database
            IdentityResult result = await _userManager.UpdateAsync(user);

            // send them back to coinflip game view
            return View("Coinflip");
        }

        public IActionResult Coinflip()
        {
            /* Get the current logged in user. */
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(ViewBag.userId).Result;
            ViewBag.User = user;

            return View();
        }

        public IActionResult PlayBlackjack(string bet)
        {
            /* Get the current logged in user. */
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(ViewBag.userId).Result;
            ViewBag.User = user;

            // play blackjack
            BlackjackGame blackjack = new BlackjackGame();

            return View("Blackjack");
        }

        public IActionResult Blackjack()
        {
            /* Get the current logged in user. */
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(ViewBag.userId).Result;
            ViewBag.User = user;

            return View();
        }
    }
}