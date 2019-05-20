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
                        Price = 0.4,
                        Promotion = Entities.Enum.Promotion.Light
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("40c8ebe5-1c89-4877-9be2-febf94363dbd"),
                        Name = "Bacon",
                        Price = 2,
                        Promotion = Entities.Enum.Promotion.Light
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("d26d3c66-ad94-4730-b040-d8842f3476b0"),
                        Name = "Hambúrguer de carne",
                        Price = 3,
                        Promotion = Entities.Enum.Promotion.ExtraMeat
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("65b3e0b6-7e49-45fa-a04b-ecf5851248e8"),
                        Name = "Ovo",
                        Price = 0.8,
                        Promotion = Entities.Enum.Promotion.None
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("2e7bf943-7b46-42a8-9d53-130ce8eff10f"),
                        Name = "Queijo",
                        Price = 1.5,
                        Promotion = Entities.Enum.Promotion.ExtraCheese
                    },
            };
        }

        public double GetPricePromotion(Ingredient entity, int amount)
        {
            if (entity.Promotion == Entities.Enum.Promotion.ExtraMeat || entity.Promotion == Entities.Enum.Promotion.ExtraCheese)
            {
                var discount = (int)(amount / 3);
                return entity.Price * (amount - discount);
            }

            return (entity.Price * amount);
        }

        public double GetPricePromotion(IList<Ingredient> entities, double total)
        {
            var ingredients = entities.Where(c => c.Promotion == Entities.Enum.Promotion.Light);

            if (ingredients.Count() == 1)
            {
                if (ingredients.Where(c => c.Name == "Alface").Any())
                {
                    double percentage = 10.0 / 100;

                    return total - (percentage * total);
                }
            }

            return total;
        }
    }
}
