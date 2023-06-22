using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrackUPSC.Models;

namespace TrackUPSC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		public static QuestionModel questionModel;

        public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
            questionModel = new QuestionModel("/Users/dhivya/Downloads/tu/1981.txt");

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
	}
}