using ChefSnacks.Core.Entities;
using ChefSnacks.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChefSnacks.Test
{
    public class SnackServiceTest
    {
        private readonly IngredientService ingredientService;
        private readonly SnackService skackService;

        public SnackServiceTest()
        {
            this.ingredientService = new IngredientService();
            this.skackService = new SnackService(ingredientService);
        }

        public List<Ingredient> CreateIngredientsValid()
        {
            return ingredientService.GetIngredients().Where(c =>
                               c.Id == Guid.Parse("40c8ebe5-1c89-4877-9be2-febf94363dbd") ||
                               c.Id == Guid.Parse("d26d3c66-ad94-4730-b040-d8842f3476b0") ||
                               c.Id == Guid.Parse("2e7bf943-7b46-42a8-9d53-130ce8eff10f")).ToList();
        }

        public Snack CreateSnackValid()
        {
            return new Snack()
            {
                Id = Guid.Parse("396f7183-db68-40e5-b954-7cc0004e6fbf"),
                Name = "X-Bacon",
                Ingredients = CreateIngredientsValid(),
            };
        }


        [Fact]
        public void When_Call_GetPrice_Passing_Snack_Entity()
        {
            //arrange
            var snack = CreateSnackValid();

            //act
            var result = skackService.GetPrice(snack);

            //assert
            Assert.Equal(result, CreateIngredientsValid().Sum(c => c.Price));
        }
    }
}
