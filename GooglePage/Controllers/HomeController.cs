using Core.Dtos;
using Core.Entites;
using GooglePage.Models;
using GoogleWebService.GoogleServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GooglePage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static PostedDto _title;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }
        /// <summary>
        /// ///the Honme Page 
        /// you can search for what you need then save what you need to search for in _title
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(PostedDto searchingTitle)

        {
            _title = searchingTitle;
            if (_title == null)
            {
                _title = new PostedDto();
                _title.Title = string.Empty;
                return RedirectToAction("Result");
            }
            else
                return RedirectToAction("Result");

        }

        /// <summary>
        /// it search for the content by the title using _title 
        /// </summary>
        /// <returns>List of <Posted> </returns>
        public IActionResult Result()
        {
            try
            {
                var service = new GoogleService();
                var resultRecived = service.GetPosts(_title);
                if (resultRecived != null && resultRecived.Count != 0)
                {
                    return View(resultRecived);
                }
                else
                {
                    Posted AddFake = new Posted() { Title = "Sorry", Contatns = "There is no Data to view it in this Title" };
                    List<Posted> ReplaceResult = new List<Posted>();


                    ReplaceResult.Add(AddFake);
                    return View(ReplaceResult);
                }
            }
            catch (Exception ex) { throw; }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
