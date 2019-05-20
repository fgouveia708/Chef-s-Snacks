using ChefSnacks.Core.Entities;
using ChefSnacks.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChefSnacks.Core.Services
{
    public class SnackService : ISnackService
    {
        private IIngredientService ingredientService;

        public SnackService(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        public IEnumerable<Snack> GetSnacks()
        {
            var ingredients = ingredientService.GetIngredients();

            return new List<Snack>() {
                new Snack() {
                    Id = Guid.Parse("396f7183-db68-40e5-b954-7cc0004e6fbf"),
                    Name = "X-Bacon",
                    Ingredients = ingredients.Where(c =>
                                   c.Id == Guid.Parse("40c8ebe5-1c89-4877-9be2-febf94363dbd") ||
                                   c.Id == Guid.Parse("d26d3c66-ad94-4730-b040-d8842f3476b0") ||
                                   c.Id == Guid.Parse("2e7bf943-7b46-42a8-9d53-130ce8eff10f")).ToList(),
                },
                new Snack() {
                    Id = Guid.Parse("a50495ba-cddc-45fb-b32e-8e9490c9b14c"),
                    Name = "X-Burger",
                    Ingredients = ingredients.Where(c =>
                                   c.Id == Guid.Parse("d26d3c66-ad94-4730-b040-d8842f3476b0") ||
                                   c.Id == Guid.Parse("2e7bf943-7b46-42a8-9d53-130ce8eff10f")).ToList()
                },
                 new Snack() {
                    Id = Guid.Parse("b11974f0-c1ce-4758-bd7a-5ef3de414933"),
                    Name = "X-Egg",
                    Ingredients = ingredients.Where(c =>
                                   c.Id == Guid.Parse("65b3e0b6-7e49-45fa-a04b-ecf5851248e8") ||
                                   c.Id == Guid.Parse("d26d3c66-ad94-4730-b040-d8842f3476b0") ||
                                   c.Id == Guid.Parse("2e7bf943-7b46-42a8-9d53-130ce8eff10f")).ToList()
                },
                 new Snack() {
                    Id = Guid.Parse("8f62ebc7-2dcc-4d93-9c06-93c1b1a0a124"),
                    Name = "X-Egg Bacon",
                    Ingredients = ingredients.Where(c =>
                                   c.Id == Guid.Parse("40c8ebe5-1c89-4877-9be2-febf94363dbd") ||
                                   c.Id == Guid.Parse("65b3e0b6-7e49-45fa-a04b-ecf5851248e8") ||
                                   c.Id == Guid.Parse("d26d3c66-ad94-4730-b040-d8842f3476b0") ||
                                   c.Id == Guid.Parse("2e7bf943-7b46-42a8-9d53-130ce8eff10f")).ToList()
                },
            };
        }

        public double GetPrice(Snack entity)
        {
            return entity.Ingredients.Sum(c => c.Price);
        }

        
    }
}
