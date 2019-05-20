using ChefSnacks.Core.Entities;
using System.Collections.Generic;

namespace ChefSnacks.Core.Interfaces
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetIngredients();
        double GetPricePromotion(Ingredient entity, int amount);
        double GetPricePromotion(IList<Ingredient> entities, double total);
    }
}
