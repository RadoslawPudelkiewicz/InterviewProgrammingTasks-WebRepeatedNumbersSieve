using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebRepeatedNumbersSieve.Models;

namespace WebRepeatedNumbersSieve.Controllers
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

        [HttpPost]
        public IActionResult TransformLiteral(string literal)
        {
            ViewData["inputLiteral"] = literal;
            ViewData["outputLiteral"] = literal + "TEST";
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}