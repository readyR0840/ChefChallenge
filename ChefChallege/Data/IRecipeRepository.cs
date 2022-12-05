using System.Linq;
using ChefChallege.Models;

namespace ChefChallege.Data
{
    public interface IRecipeRepository
    {
        IQueryable<DesertRecipe> DesertRecipes { get; }  // property that can contain a collection of recipes
        IQueryable<DinnerRecipe> DinnerRecipes { get; }
        IQueryable<SoupRecipe> SoupRecipes { get; }
        IQueryable<Ingredient> Ingredients { get; }
        IQueryable<User> Users { get; }
        int AddDesertRecipe(DesertRecipe recipe); // method to add a recipe to the DB
        int AddDinnerRecipe(DinnerRecipe recipe);
        int AddSoupRecipe(SoupRecipe recipe);
        void AddIngredients(Ingredient ingredient);// method to add required ingredients to database to draw from
        public int AddUser(User user);
        public int AddDinnerRating(int id, int rating);
        public int AddDesertRating(int id, int rating);
        public int AddSoupRating(int id, int rating);

    }
}
