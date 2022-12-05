using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ChefChallege.Data;
using ChefChallege.Models;

namespace TestAllControllers.FakeRepository
{
    public class FakeRecipeRepository : IRecipeRepository
    {
        private List<DesertRecipe> desertRecipes = new List<DesertRecipe>();
        private List<DinnerRecipe> dinnerRecipes = new List<DinnerRecipe>();
        private List<SoupRecipe> soupRecipes = new List<SoupRecipe>();
        private List<User> users = new List<User>();
        private List<Ingredient> ingredients = new List<Ingredient>();

        IQueryable<DesertRecipe> IRecipeRepository.DesertRecipes { get { return desertRecipes.AsQueryable(); } }

        IQueryable<DinnerRecipe> IRecipeRepository.DinnerRecipes { get { return dinnerRecipes.AsQueryable(); } }

        IQueryable<SoupRecipe> IRecipeRepository.SoupRecipes { get { return soupRecipes.AsQueryable(); } }

        IQueryable<Ingredient> IRecipeRepository.Ingredients { get { return ingredients.AsQueryable(); } }

        IQueryable<User> IRecipeRepository.Users { get { return users.AsQueryable(); } }

        public int AddDesertRating(int id, int rating)
        {
            int status = 0;
            if (rating != 0)
            {
                this.desertRecipes[id - 1].Rating = rating;
                status = 1;
            }
            return (status);
        }

        public int AddDesertRecipe(DesertRecipe recipe)
        {
            
            int status = 0;
            if (recipe != null)
            {
                recipe.Id = desertRecipes.Count;
                desertRecipes.Add(recipe); 
                status = 1;
            }
            return (status);
        }

        public int AddDinnerRating(int id, int rating)
        {
            int status = 0;
            if (rating != 0)
            {
                this.dinnerRecipes[id - 1].Rating = rating;
                status = 1;
            }
            return (status);
        }

        public int AddDinnerRecipe(DinnerRecipe recipe)
        {
            int status = 0;
            if (recipe != null)
            {
                recipe.Id = dinnerRecipes.Count;
                dinnerRecipes.Add(recipe);
                status = 1;
            }
            return (status);
        }

        public void AddIngredients(Ingredient ingredient)
        {
            if (ingredient != null)
            {
                ingredient.Id = desertRecipes.Count;
                ingredients.Add(ingredient);
            }
        }

        public int AddSoupRating(int id, int rating)
        {
            int status = 0;
            if (rating != 0)
            {
                this.soupRecipes[id - 1].Rating = rating;
                status = 1;
            }
            return (status);
        }

        public int AddSoupRecipe(SoupRecipe recipe)
        {
            int status = 0;
            if (recipe != null)
            {
                recipe.Id = soupRecipes.Count;
                soupRecipes.Add(recipe);
                status = 1;
            }
            return (status);
        }
        public int AddUser(User user)
        {
            
            int status = 0;
            if (user != null)
            {
                users.Add(user);
                status = 1;
            }
            return (status);
        }

        public IRecipe GetDesertRecipeByName(string name)
        {
            throw new NotImplementedException();
        }

        public IRecipe GetDesertRecipeByUserName(string username)
        {
            return (IRecipe)desertRecipes.Where(i => i.User.UserName == username).ToList();
        }

        public IRecipe GetDinnerRecipeByName(string name)
        {
            throw new NotImplementedException();
        }

        public IRecipe GetDinnerRecipeByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public IRecipe GetSoupRecipeByName(string name)
        {
            throw new NotImplementedException();
        }

        public IRecipe GetSoupRecipeByUserName(string username)
        {
            throw new NotImplementedException();
        }
    }
}
