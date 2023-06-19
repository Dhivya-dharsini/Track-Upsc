using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using TrackUPSC.Models;

namespace TrackUPSC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		static QuestionModel questionModel;
        static List<string> terms = new List<string>();

        public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
            questionModel=new QuestionModel("/Users/dhivya/Downloads/tu/1981.txt");


            string[] questionFileData = System.IO.File.ReadAllLines("/Users/dhivya/Downloads/tu/Term.txt");
            for (int line = 0; line < questionFileData.Length; line++)
			{
				terms.Add(questionFileData[line]);
			}

            return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult SearchQuestions(string searchKeyword)
		{
			string[] searchSplit = searchKeyword.Split(' ');
			for(int i = 0; i < searchSplit.Length; i++)
			{

			}
		//	questions.Select(X => X).Where(X => X.question.Contains(searchKeyword) || X.answerOne.Contains(searchKeyword) || X.answerTwo.Contains(searchKeyword) || X.answerThree.Contains(searchKeyword) || X.answerFour.Contains(searchKeyword)).ToList();
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}