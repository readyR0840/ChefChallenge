using ChefChallege.Data;
using ChefChallege.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChefChallege.Controllers
{
    public class AddDinnerController : Controller
    {
        IRecipeRepository repo;

        public AddDinnerController(IRecipeRepository r)
        {
            this.repo = r;
        }
        public IActionResult Index(string name)
        {
            var list = this.repo.DinnerRecipes.ToList();
            if(name != null)
            {
                list = this.repo.DinnerRecipes.Where(d => d.Name == name).ToList();
            }
            return View(list);
        }
        [HttpPost]
        public IActionResult Index(int id, int r)
        {
            if (this.repo.DinnerRecipes.Where(i => i.Id == id) != null)
            {
                this.repo.AddDinnerRating(id, r);
            }
            return View();
        }
        public IActionResult AddDinner()
        {
            DinnerRecipe recipe = new DinnerRecipe();
            return View(recipe);
        }
        [HttpPost]
        public IActionResult AddDinner(DinnerRecipe r)
        {
            r.RequiredIngredients = repo.Ingredients.Where(i => i.Type == "Dinner").ToList();
            r.User = repo.Users.OrderBy(u => u.Id).Last();
            this.repo.AddDinnerRecipe(r);
            return View("Index");
        }
    }
}
