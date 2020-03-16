using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlackjackTycoon.Controllers
{
    public class CoinflipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}