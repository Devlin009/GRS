using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;

        private AddDbContext Context { get; }

        public HomeController(AddDbContext _context)
        {
            this.Context = _context;
        }
        //public homecontroller(ilogger<homecontroller> logger)
        //{
        //    _logger = logger;
        //}
        [HttpGet]
        public IActionResult Index()
        {
            
            return View(Context.Users.ToList());
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
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var data = Context.Users.Find(id);
            Context.Users.Remove(data);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            User up = Context.Users.Find(id);
            
            return View(up);
        }
      
      
        [HttpPost]
        public IActionResult Dataab(User? users)
        {
            var u = Context.Users.Find(users.Id);
            u.name = users.name;
            u.email = users.email;
            u.password = users.password;
            u.cpassword = users.cpassword;
            this.Context.SaveChanges();

            return RedirectToAction("Index");


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