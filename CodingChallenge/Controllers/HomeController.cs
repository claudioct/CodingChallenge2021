using CodingChallenge.Data;
using CodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CodingChallengeContext _codingChallengeContext;

        public HomeController(ILogger<HomeController> logger, CodingChallengeContext codingChallengeContext)
        {
            _logger = logger;
            _codingChallengeContext = codingChallengeContext;
        }

        public IActionResult Index()
        {
            var post = _codingChallengeContext.Post.Single(p => p.Id.Equals(new Guid("225F876B-7BF8-43C6-AEC4-8A0C91F83E88")));
            return View(post);
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
