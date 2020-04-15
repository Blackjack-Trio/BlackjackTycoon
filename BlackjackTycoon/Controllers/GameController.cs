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

        public async Task<IActionResult> Coinflip(string coin, string bet, bool play = false)
        {
            /* Errors array */
            ViewBag.Errors = new List<string>();

            /* Get the current logged in user. */
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(ViewBag.userId).Result;
            ViewBag.User = user;

            /* If play = true validate inputs + run game logic */
            if (play)
            {
                /* validation */
                if (coin == null) ViewBag.Errors.Add("Please select heads or tails.");
                if (!int.TryParse(bet, out int i)) ViewBag.Errors.Add("The bet must be an integer.");
                if (i > user.Bankroll) ViewBag.Errors.Add("You don't have enough money to place that bet.");
                /* If any errors got added we'll return the view now */
                if (ViewBag.Errors.Count >= 1) return View();

                /* game logic */
                CoinflipGame coinflip = new CoinflipGame();
                coinflip.Player = user;

                if (coinflip.Play(coin, int.Parse(bet)))
                {
                    ViewBag.GameResults = "Winner! You won $" + (int.Parse(bet)*2);
                    ViewBag.LastGame = true;
                }
                else
                {
                    ViewBag.GameResults = "Loser! You lost $" + int.Parse(bet);
                    ViewBag.LastGame = false;
                }

                IdentityResult result = await _userManager.UpdateAsync(user);
            }
            
            return View();
        }

        public IActionResult Blackjack()
        {
            return View();
        }
    }
}