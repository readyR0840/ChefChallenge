using ChefChallege.Data;
using ChefChallege.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ChefChallege.Controllers
{
    public class AddSoupController : Controller
    {
        IRecipeRepository repo;

        public AddSoupController(IRecipeRepository r)
        {
            this.repo = r;
        }
        public IActionResult Index(string name)
        {
            var list = this.repo.SoupRecipes.ToList();
            if (name != null)
            {
                list = this.repo.SoupRecipes.Where(d => d.Name == name).ToList();
            }
            return View(list);
        }
        [HttpPost]
        public IActionResult Index(int id, int r)
        {
            if(this.repo.SoupRecipes.Where(i => i.Id == id) != null)
            {
                this.repo.AddSoupRating(id, r);
            }
            return View();
        }
        public IActionResult AddSoup()
        {
            SoupRecipe recipe = new SoupRecipe();
            return View(recipe);
        }
        [HttpPost]
        public IActionResult AddSoup(SoupRecipe r)
        {
            r.RequiredIngredients = repo.Ingredients.Where(i => i.Type == "Soup").ToList();
            r.User = repo.Users.OrderBy(u => u.Id).Last();
            this.repo.AddSoupRecipe(r);
            return View("Index");
        }
    }
}
