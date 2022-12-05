using ChefChallege.Data;
using ChefChallege.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChefChallege.Controllers
{
    public class HomeController : Controller
    {
        IRecipeRepository repo;
        public HomeController(IRecipeRepository r)
        {
            this.repo = r;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var list = repo.Users.ToList();
            return View(list);
        }
        public IActionResult UserSignIn()
        {
            User u = new User();
            return View(u);
        }
        [HttpPost]
        public IActionResult UserSignIn(User user)
        {
            repo.AddUser(user);
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
