using ChefSnacks.Core.Entities;
using ChefSnacks.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChefSnacks.Core.Services
{
    public class IngredientService : IIngredientService
    {

        public IEnumerable<Ingredient> GetIngredients()
        {
            return new List<Ingredient>(){
                    new Ingredient()
                    {
                        Id = Guid.Parse("11e532f4-7df0-4e93-8408-bd27e6969b08"),
                        Name = "Alface",
                        Price = 0.4
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("40c8ebe5-1c89-4877-9be2-febf94363dbd"),
                        Name = "Bacon",
                        Price = 2
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("d26d3c66-ad94-4730-b040-d8842f3476b0"),
                        Name = "Hambúrguer de carne",
                        Price = 3
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("65b3e0b6-7e49-45fa-a04b-ecf5851248e8"),
                        Name = "Ovo",
                        Price = 0.8
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("2e7bf943-7b46-42a8-9d53-130ce8eff10f"),
                        Name = "Queijo",
                        Price = 1.5
                    },
            };
        }

        public double GetPricePromotion(Guid id, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
