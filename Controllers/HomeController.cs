using ContactPro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactPro.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        //this string must match one in program cs 
        //custom error page
        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            var customError = new CustomError();

            //prop in model then param
            customError.Code = code;

            if (code == 404)
            {
                customError.Message = "The page you are looking for may have been removed, had it's name changed or is temporarily unavailable.";
            }
            else
            {
                customError.Message = "Sorry something wnet wrong";
            }

            //more personalized or direct
            return View("~/Views/Shared/CustomError.cshtml", customError);
            //return View(customError);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}