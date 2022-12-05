using ChefChallege.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChefChallege.Data
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.User.Any())
            {
                List<Ingredient> listIng1 = new List<Ingredient>();
                List<Ingredient> listIng2 = new List<Ingredient>();
                List<Ingredient> listIng3 = new List<Ingredient>();
                Ingredient ing = new Ingredient();
                ing.Name = "Cheddar Cheese";
                ing.Amount = "3oz";
                ing.Type = "Dinner";
                context.Ingredient.Add(ing);
                context.SaveChanges();
                Ingredient ing1 = new Ingredient();
                ing1.Name = "Oranges";
                ing1.Amount = "6oz";
                ing1.Type = "Desert";
                context.Ingredient.Add(ing1);
                context.SaveChanges();
                Ingredient ing2 = new Ingredient();
                ing2.Name = "Navy Beans";
                ing2.Amount = "7oz";
                ing2.Type = "Soup";
                context.Ingredient.Add(ing2);
                context.SaveChanges();
                listIng1.Add(ing);
                listIng2.Add(ing1);
                listIng3.Add(ing2);
                User user = new User();
                user.UserName = "Master Chef";
                user.Age = 35;
                user.State = "Oregon";
                user.Experience = "Expert";
                context.User.Add(user);
                context.SaveChanges();
                DinnerRecipe recipe = new DinnerRecipe();
                recipe.Name = "Western Omelet";
                recipe.Ingredients = "salt, pepper, sugar, eggs, oil";
                recipe.Amounts = "1 tsp, 2 tsp, 3 tsp, 3 large, 3 tbsp";
                recipe.Instructions = "Heat pan to medium-high heat, pour in some oil, add the eggs and ingredients, cook until firm, then add cheese.";
                recipe.RequiredIngredients = (listIng1);
                recipe.User = user;
                DinnerRecipe recipe1 = new DinnerRecipe();
                recipe1.Name = "Pork Roast";
                recipe1.Ingredients = "salt, pepper, sage, beets, leeks";
                recipe1.Amounts = "3 tsp, 3 tsp, 4tsp, 2 whole, 2 whole";
                recipe1.Instructions = "Take the roast and rub it down with salt and pepper, sear until golden brown, bake for 30 minutes at 375 degrees with other ingredients.";
                recipe1.RequiredIngredients = (listIng1);
                recipe1.User = user;
                context.DinnerRecipe.Add(recipe);
                context.SaveChanges();
                context.DinnerRecipe.Add(recipe1);
                context.SaveChanges();
                DesertRecipe recipe2 = new DesertRecipe();
                recipe2.Name = "Chocolate Orange Cake";
                recipe2.Ingredients = "salt, pepper, sugar, flour, oil, eggs";
                recipe2.Amounts = "1 tsp, 2 tsp, 3 tsp, 4 oz, 3 tbsp, 2 small";
                recipe2.Instructions = "Pour ingredients in a bowl, mix together to form a batter, cook in a greased baking pan at 350 degrees for 2 hours. Serve with slices of oranges.";
                recipe2.RequiredIngredients = (listIng2);
                recipe2.User = user;
                DesertRecipe recipe3 = new DesertRecipe();
                recipe3.Name = "Orange Pudding";
                recipe3.Ingredients = "cinnimon, whole wheat flour, salt, tumeric, butter";
                recipe3.Amounts = "4tsp, 5 oz, 6 tsp, 2 tsp, 2 tsp, 1 oz";
                recipe3.Instructions = "Take the ingredients, mix them up, cook them over a pan while stirring, throw in the sliced oranges, then add more flour as necessary.";
                recipe3.RequiredIngredients = (listIng2);
                recipe3.User = user;
                context.DesertRecipe.Add(recipe2);
                context.SaveChanges();
                context.DesertRecipe.Add(recipe3);
                context.SaveChanges();
                SoupRecipe recipe4 = new SoupRecipe();
                recipe4.Name = "Spicy Bean Soup";
                recipe4.Ingredients = "salt, pepper, sugar, flour, onions";
                recipe4.Amounts = "1tsp, 2tsp, 3tsp, 4oz, 2 1/2 small";
                recipe4.Instructions = "Heat in large pot full of water, for 2 hours, checking occasionally.";
                recipe4.RequiredIngredients = (listIng3);
                recipe4.User = user;
                SoupRecipe recipe5 = new SoupRecipe();
                recipe5.Name = "Pork & Beans";
                recipe5.Ingredients = "sage, cinnimon, whole wheat flour, beets, leeks, pork";
                recipe5.Amounts = "4tsp, 5tsp, 6tsp, 7oz, 4 whole, 2 lbs";
                recipe5.Instructions = "Cook for 3 hours, low heat, stirring occasionally.";
                recipe5.RequiredIngredients = (listIng3);
                recipe5.User = user;
                context.SoupRecipe.Add(recipe4);
                context.SaveChanges();
                context.SoupRecipe.Add(recipe5);
                context.SaveChanges();
            }
        }
    }
}
