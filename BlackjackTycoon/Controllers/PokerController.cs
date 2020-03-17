using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackjackTycoon.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackjackTycoon.Controllers
{
    public class PokerController : Controller
    {
        public IActionResult Index(GameSetupViewModel model)
        {
            /* At this point we should have everything needed to build the game object and begin playing.
               We're using the validation provided by .NET but we'll want to add custom validation also. */ 
            ViewBag.Game = model.GameName;
            ViewBag.Money = model.PlayingMoney;
            return View();
        }
    }
}