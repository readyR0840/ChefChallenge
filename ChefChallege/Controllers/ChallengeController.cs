using ChefChallege.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Security.AccessControl;
using System.Xml.Linq;
using ChefChallege.Data;
using System.Linq;

namespace ChefChallege.Controllers
{
    public class ChallengeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
