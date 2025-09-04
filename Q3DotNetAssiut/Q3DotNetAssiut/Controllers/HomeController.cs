using Microsoft.AspNetCore.Mvc;
using Q3DotNetAssiut.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace Q3DotNetAssiut.Controllers
{
    public class HomeController : Controller
    {

        // 1- Method Public
        // 2- Cant be static
        // 3- Cant be Overload

        // /Home/ShowMsg
        public ContentResult ShowMsg()
        {
            // 1- declare
            ContentResult result = new ContentResult();

            // 2- initial 
            result.Content = $"Hello {5 + 6}";

            // 3- return
            return result;
        }

        // /Home/ShowView
        public ViewResult ShowView()
        {
            // 1- logic
            ViewResult result = new ViewResult();

            // 2- declare
            // 3- initial 
            result.ViewName = $"View1";

            // 4- return
            return result;
        }

        // /Home/ShowMix?id=1&name=ahmed
        // /home/ShowMix? id = 4 & name = fady
        public IActionResult ShowMix(int id, string name)
        {
            if (id % 2 == 0)
            {
                return View("View1");
            }
            else
            {
                return Content("Hello");
            }
        }


        // /Home/ShowMsg
        //public String ShowMsg()
        //{
        //    int a = 15;
        //    int b = 15;
        //    int z = a + b;
        //    string msg= "Hello World";
        //    return $"{msg} + {z} ";
        //}



        //Action Return type
        //String--> ContentREsult
        //View  -->ViewResult
        //Json  -->JSonResult
        //File  -->FileResult
        //notfound ->NotFoundREsult
        //unauthor ->UnAuthoriResult


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
