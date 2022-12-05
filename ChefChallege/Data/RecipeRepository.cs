using ChefChallege.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ChefChallege.Data
{
    public class RecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;
        public IQueryable<DesertRecipe> DesertRecipes
        {
            get
            {
                return context.DesertRecipe.Include(i => i.RequiredIngredients).Include(u => u.User);
            }
        }
        public IQueryable<SoupRecipe> SoupRecipes
        {
            get
            {
                return context.SoupRecipe.Include(i => i.RequiredIngredients).Include(u => u.User);
            }
        }
        public IQueryable<DinnerRecipe> DinnerRecipes
        {
            get
            {
                return context.DinnerRecipe.Include(i => i.RequiredIngredients).Include(u => u.User);
            }
        }
        public IQueryable<User> Users
        {
            get
            {
                return context.User;
            }
        }
        public IQueryable<Ingredient> Ingredients
        {
            get
            {
                return context.Ingredient;
            }
        }
        public RecipeRepository(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        public int AddUser(User user)
        {
            context.User.Add(user);
            return context.SaveChanges();
        }

        public User GetUserByUserName(string username)
        {
            return context.User.First(n => n.UserName == username);
        }
        public void AddIngredients(Ingredient ingredient)
        {
            context.Ingredient.Add(ingredient);
            context.SaveChanges();
        }

        public int AddDesertRecipe(DesertRecipe recipe)
        {
            context.DesertRecipe.Add(recipe);
            return context.SaveChanges();
        }
        public int AddSoupRecipe(SoupRecipe recipe)
        {
            context.SoupRecipe.Add(recipe);
            return context.SaveChanges();
        }
        public int AddDinnerRecipe(DinnerRecipe recipe)
        {
            context.DinnerRecipe.Add(recipe);
            return context.SaveChanges();
        }
        public int AddDinnerRating(int id, int rating)
        {
            context.DinnerRecipe.Find(id).Rating = rating;
            return context.SaveChanges();
        }
        public int AddDesertRating(int id, int rating)
        {
            context.DesertRecipe.Find(id).Rating = rating;
            return context.SaveChanges();
        }
        public int AddSoupRating(int id, int rating)
        {
            context.SoupRecipe.Find(id).Rating = rating;
            return context.SaveChanges();
        }
    }
}
