using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TacoCatMVC.Models;

namespace TacoCatMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Code()
        {
            return View();
        }
        public IActionResult Solve()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Solve(string theWord, string anotherWord)
        {
            if (string.IsNullOrWhiteSpace(theWord) || string.IsNullOrWhiteSpace(anotherWord))
            {
                return View();
            }
            var result = theWord.ToLower().Replace(" ","");
            var result2 = anotherWord.ToLower().Replace(" ", "");
            var reverse = string.Join("", result.Reverse().ToArray());
            var reverse2 = string.Join("", result2.Reverse().ToArray());
            if (reverse == result && reverse2 == result2)
            {
                ViewData["BothPal"] = "Both " + result + " and " + result2 + " are palindromes";
            } else if ( reverse == result)
            {
                ViewData["FirstPal"] = result + " is a palindrome";
            } else if (reverse2 == result2)
            {
                ViewData["secondPal"] = result2 + " is a palindrome";
            } else
            {
                ViewData["NoPal"] = "Neither words are palindromes";
            }

            ViewData["ReversedWord"] = reverse;
            ViewData["reversedWordTwo"] = reverse2;
            return View();


        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
