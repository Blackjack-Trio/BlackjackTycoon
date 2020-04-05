using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackjackTycoon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackjackTycoon.Controllers
{
    public class GameController : Controller
    {

        /* We get here from the GameSetup.cshtml page. */
        public IActionResult Index(GameSetupViewModel model)
        {
            /* At this point we should have everything needed to build the game object and begin playing.
               We're using the validation provided by .NET but we'll want to add custom validation also. (i think) */ 
            ViewBag.Game = model.GameName;
            ViewBag.Money = model.PlayingMoney;
            /* Switch case to check name of game they selected so we know what game view to load. This was added to combine game views. */
            switch (model.GameName)
            {
                case "coinflip":
                    return RedirectToAction("Coinflip", "Game");

                case "blackjack":
                    return RedirectToAction("Blackjack", "Game");

                default:
                    Console.WriteLine("Default case");
                    return View();
            }
        }
        
        /* This is where coinflip game logic is living */
        [HttpPost]
        public IActionResult PlayCoinflip()
        {
            Random random = new Random();
            var n = random.Next(0, 2);
            ViewBag.test = "Test";

            /* After game logic serve the view again. */
            return RedirectToAction("Coinflip", "Game");
        }

        public IActionResult PlayBlackjack()
        {

            /* After game logic serve the view again. */
            return RedirectToAction("Blackjack", "Game");
        }

        /* This is where we serve the view */
        public IActionResult Coinflip()
        {
            return View();
        }

        public IActionResult Blackjack()
        {
            return View();
        }
    }
}