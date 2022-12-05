using ChefChallege.Data;
using ChefChallege.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ChefChallege.Controllers
{
    public class AddDesertController : Controller
    {
        IRecipeRepository repo;

        public AddDesertController(IRecipeRepository r)
        {
            this.repo = r;
        }
        [HttpGet]
        public IActionResult Index(string name)
        {
            var list = this.repo.DesertRecipes.ToList();
            if (name != null)
            {
                list = this.repo.DesertRecipes.Where(d => d.Name == name).ToList();
            }
            return View(list);
        }
        [HttpPost]
        public IActionResult Index(int id, int r)
        {
            if (this.repo.DesertRecipes.Where(i=>i.Id == id) != null)
            {
                this.repo.AddDesertRating(id, r);
            }
            return View();
        }
        public IActionResult AddDesert()
        {
            DesertRecipe recipe = new DesertRecipe();
            return View(recipe);
        }
        [HttpPost]
        public IActionResult AddDesert(DesertRecipe r)
        {
            r.RequiredIngredients = repo.Ingredients.Where(i => i.Type == "Desert").ToList();
            r.User = repo.Users.OrderBy(u => u.Id).Last();
            this.repo.AddDesertRecipe(r);
            return View("Index");
        }
    }
}
