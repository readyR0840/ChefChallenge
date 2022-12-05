using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefChallege.Models
{
    public interface IRecipe

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
        public User User { get; set; }
            public string[] IngredientsList
            {
                get
                {
                    return Ingredients.Split(", ");
                }
            }
            public string[] AmountsList
            {
                get
                {
                    return Amounts.Split(", ");
                }
            }
    }
}
