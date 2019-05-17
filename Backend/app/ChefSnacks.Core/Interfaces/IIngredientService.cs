using ChefSnacks.Core.Entities;
using System.Collections.Generic;

namespace ChefSnacks.Core.Interfaces
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetIngredients();
    }
}
