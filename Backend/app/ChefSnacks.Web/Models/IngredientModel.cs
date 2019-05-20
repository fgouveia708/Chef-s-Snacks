using ChefSnacks.Core.Entities;
using System.Collections.Generic;

namespace ChefSnacks.Web.Models
{
    public class IngredientModel
    {
        public IList<Ingredient> Ingredients { get; set; }
        public double Total { get; set; }
    }
}
