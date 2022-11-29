using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebRepeatedNumbersSieve.Models;

namespace WebRepeatedNumbersSieve.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILiteralTransformationEngine _literalTransformationEngine;

        public HomeController(ILogger<HomeController> logger, ILiteralTransformationEngine literalTransformationEngine)
        {
            _logger = logger;
            _literalTransformationEngine = literalTransformationEngine;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TransformLiteral(string literal)
        {
            ViewData["inputLiteral"] = literal;
            ViewData["outputLiteral"] = _literalTransformationEngine.DoLiteralTransformation(literal);
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}