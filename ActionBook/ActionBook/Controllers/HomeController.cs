using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ActionBook.Models;

namespace ActionBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly MasterContext _context;

        public HomeController(MasterContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> About(string name)
        {
            if (name == null)
            {
                return View();
            }

            ViewData["Message"] = "Your application description page.";

            var actionBook = new ActionBooks
            {
                Id = 0,
                ActionLists = new List<ActionLists>(),
                Name = name
            };

            if (ModelState.IsValid)
            {
                _context.Add(actionBook);
                await _context.SaveChangesAsync();
                ViewBag.BookId = actionBook.Id;

                return PartialView("_StaticRenderPage", actionBook);
            }

            return Json(actionBook);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Type4(ActionBooks book)
        {
            ViewData["Message"] = "Your Type.";
            
            return View(book);
        }
        public IActionResult Type3(ActionBooks book)
        {
            ViewData["Message"] = "Your application .";

            return View(book);
        }
        public IActionResult Type2(ActionBooks book)
        {
            ViewData["Message"] = "Your application .";

            return View(book);
        }
        public IActionResult Type1(ActionBooks book)
        {
            ViewData["Message"] = "Your application .";

            return View(book);
        }
    }
}
