using ChefSnacks.Core.Entities;
using System;
using System.Collections.Generic;

namespace ChefSnacks.Core.Interfaces
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetIngredients();
        double GetPricePromotion(Guid id, int amount);
    }
}
