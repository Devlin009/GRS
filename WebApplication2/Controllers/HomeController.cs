using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AddDbContext Context { get; }

        public HomeController(AddDbContext _context)
        {
            this.Context = _context;
        }
        //public homecontroller(ilogger<homecontroller> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            ViewBag.products = Context.User.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        public IActionResult About()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult About(User user)
        {
            this.Context.User.Add(user);
            this.Context.SaveChanges();
            return View(user);

        }




        //public IActionResult About(string name, string email, string password, string cpassword)
        //{
        //    var viewModel = new User()
        //    {
        //        name = name,
        //    email = email,
        //    password = password,
        //    cpassword = cpassword,
        //};


        //    return View(viewModel);
        //}
        




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}