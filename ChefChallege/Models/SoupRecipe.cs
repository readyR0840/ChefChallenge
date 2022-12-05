using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefChallege.Models
{
    public class SoupRecipe : IRecipe
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public List<Ingredient> RequiredIngredients { get; set; }
        [Required]
        public string? Ingredients { get; set; }
        [Required]
        public string? Amounts { get; set; }
        [Required]
        public string? Instructions { get; set; }
        public int Rating { get; set; }
        public User User { get; set; }
        public string[] IngredientsList
        {
            get
            {
                if (Ingredients != null)
                {
                    return Ingredients.Split(", ");
                }
                else
                {
                    Ingredients = "error";
                    return Ingredients.Split(", ");
                }
            }
        }
        public string[] AmountsList
        {
            get
            {
                if (Amounts != null)
                {
                    return Amounts.Split(", ");
                }
                else
                {
                    Amounts = "error";
                    return Amounts.Split(", ");
                }
            }
        }
    }
}
