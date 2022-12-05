using ChefChallege.Controllers;
using System;
using Xunit;
using ChefChallege.Models;
using TestAllControllers.FakeRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestAllControllers
{
    public class AddRecipeControllerTests
    {
        FakeRecipeRepository repo = new FakeRecipeRepository();
        AddDesertController addDesertController;
        AddDinnerController addDinnerController;
        AddSoupController addSoupController;
        [Fact]
        public void AddDinnerRecipeIndexTest()
        {
            //Arrange
            AddRecipes();
            addDinnerController = new AddDinnerController(this.repo);
            //addDinnerController.AddDinner();
            //Act
            var result = (ViewResult)addDinnerController.Index(null);
            var recipes = (List<DinnerRecipe>)result.Model;
            //Assert
            Assert.Equal("Western Omelet", recipes[0].Name);
            Assert.Equal(2, recipes.Count);
        }
        
        [Fact]
        public void AddSoupRecipeIndexTest()
        {
            //Arrange
            AddRecipes();
            addSoupController = new AddSoupController(this.repo);
            //Act
            var result = (ViewResult)addSoupController.Index(null);
            var recipes = (List<SoupRecipe>)result.Model;
            //Assert
            Assert.Equal("Western Omelet", recipes[0].Name);
            Assert.Equal(2, recipes.Count);
        }
        [Fact]
        public void AddDesertRecipeIndexTest()
        {
            AddRecipes();
            //Arrange
            addDesertController = new AddDesertController(this.repo);
            //Act
            var result = (ViewResult)addDesertController.Index(null);
            var recipes = (List<DesertRecipe>)result.Model;
            //Assert
            Assert.Equal("Western Omelet", recipes[0].Name);
            Assert.Equal(2, recipes.Count);
        }
        [Fact]
        public void AddSoupRecipeAddSoupTest()
        {
            User user = new User();
            user.UserName = "bob";
            Ingredient i = new Ingredient();
            i.Type = "Soup";
            this.repo.AddUser(user);
            this.repo.AddIngredients(i);
            addSoupController = new AddSoupController(this.repo);
            SoupRecipe s = new SoupRecipe();
            s.Name = "add";
            //Act
            addSoupController.AddSoup(s);
            var result = (ViewResult)addSoupController.Index(null);
            var recipes = (List<SoupRecipe>)result.Model;
            //Assert
            Assert.Equal("add", recipes[0].Name);
            Assert.Equal(1, recipes.Count);
        }
        [Fact]
        public void AddDesertRecipeAddDesertTest()
        {
            User user = new User();
            user.UserName = "bob";
            Ingredient i = new Ingredient();
            i.Type = "Soup";
            this.repo.AddUser(user);
            this.repo.AddIngredients(i);
            addDesertController = new AddDesertController(this.repo);
            DesertRecipe s = new DesertRecipe();
            s.Name = "add";
            //Act
            addDesertController.AddDesert(s);
            var result = (ViewResult)addDesertController.Index(null);
            var recipes = (List<DesertRecipe>)result.Model;
            //Assert
            Assert.Equal("add", recipes[0].Name);
            Assert.Equal(1, recipes.Count);
        }
        [Fact]
        public void AddDinnerRecipeAddDinnerTest()
        {
            User user = new User();
            user.UserName = "bob";
            Ingredient i = new Ingredient();
            i.Type = "Soup";
            this.repo.AddUser(user);
            this.repo.AddIngredients(i);
            addDinnerController = new AddDinnerController(this.repo);
            DinnerRecipe s = new DinnerRecipe();
            s.Name = "add";
            //Act
            addDinnerController.AddDinner(s);
            var result = (ViewResult)addDinnerController.Index(null);
            var recipes = (List<DinnerRecipe>)result.Model;
            //Assert
            Assert.Equal("add", recipes[0].Name);
            Assert.Equal(1, recipes.Count);
        }
        [Fact]
        public void AddARating()
        {
            AddRecipes();
            addDinnerController = new AddDinnerController(this.repo);
            addDinnerController.Index(1, 1);
            //Act
            var result = (ViewResult)addDinnerController.Index(null);
            var recipes = (List<DinnerRecipe>)result.Model;
            //Assert
            Assert.Equal(1, recipes[0].Rating);
        }
        
        private void AddRecipes()
        {

            // Add some data (2 entries per recipe type)
            DinnerRecipe recipe = new DinnerRecipe();
            recipe.Name = "Western Omelet";
            recipe.Ingredients = "salt, pepper, sugar, flour, onions";
            recipe.Amounts = "1tsp, 2tsp, 3tsp, 4oz, 2 1/2 small";
            this.repo.AddDinnerRecipe(recipe);
            DinnerRecipe recipe1 = new DinnerRecipe();
            recipe1.Name = "Northern Omelet";
            recipe1.Ingredients = "sage, cinnimon, whole wheat flour, beets, leeks";
            recipe1.Amounts = "4tsp, 5tsp, 6tsp, 7oz, 8 1/2 large";
            this.repo.AddDinnerRecipe(recipe1);
            SoupRecipe recipe2 = new SoupRecipe();
            recipe2.Name = "Western Omelet";
            recipe2.Ingredients = "salt, pepper, sugar, flour, onions";
            recipe2.Amounts = "1tsp, 2tsp, 3tsp, 4oz, 2 1/2 small";
            this.repo.AddSoupRecipe(recipe2);
            SoupRecipe recipe3 = new SoupRecipe();
            recipe3.Name = "Northern Omelet";
            recipe3.Ingredients = "sage, cinnimon, whole wheat flour, beets, leeks";
            recipe3.Amounts = "4tsp, 5tsp, 6tsp, 7oz, 8 1/2 large";
            this.repo.AddSoupRecipe(recipe3);
            DesertRecipe recipe4 = new DesertRecipe();
            recipe4.Name = "Western Omelet";
            recipe4.Ingredients = "salt, pepper, sugar, flour, onions";
            recipe4.Amounts = "1tsp, 2tsp, 3tsp, 4oz, 2 1/2 small";
            this.repo.AddDesertRecipe(recipe4);
            DesertRecipe recipe5 = new DesertRecipe();
            recipe5.Name = "Northern Omelet";
            recipe5.Ingredients = "sage, cinnimon, whole wheat flour, beets, leeks";
            recipe5.Amounts = "4tsp, 5tsp, 6tsp, 7oz, 8 1/2 large";
            this.repo.AddDesertRecipe(recipe5);
        }
    }
}
