using ChefSnacks.Core.Entities;
using ChefSnacks.Core.Interfaces;
using ChefSnacks.Core.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChefSnacks.Test
{
    public class IngredientServiceTest
    {
        private readonly IngredientService ingredientService;

        public IngredientServiceTest()
        {
            this.ingredientService = new IngredientService();
        }

        public Ingredient CreateIngredientValid()
        {
            return new Ingredient()
            {
                Id = Guid.Parse("d26d3c66-ad94-4730-b040-d8842f3476b0"),
                Name = "Hambúrguer de carne",
                Price = 3,
                Promotion = Core.Entities.Enum.Promotion.ExtraMeat
            };
        }

        public List<Ingredient> CreateIngredientListWithBaconValid()
        {
            return new List<Ingredient>(){
                    new Ingredient()
                    {
                        Id = Guid.Parse("11e532f4-7df0-4e93-8408-bd27e6969b08"),
                        Name = "Alface",
                        Price = 0.4,
                        Promotion = Core.Entities.Enum.Promotion.Light
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("40c8ebe5-1c89-4877-9be2-febf94363dbd"),
                        Name = "Bacon",
                        Price = 2,
                        Promotion = Core.Entities.Enum.Promotion.Light
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("d26d3c66-ad94-4730-b040-d8842f3476b0"),
                        Name = "Hambúrguer de carne",
                        Price = 3,
                        Promotion = Core.Entities.Enum.Promotion.ExtraMeat
                    }
            };
        }

        public List<Ingredient> CreateIngredientListWithoutBaconValid()
        {
            return new List<Ingredient>(){
                    new Ingredient()
                    {
                        Id = Guid.Parse("11e532f4-7df0-4e93-8408-bd27e6969b08"),
                        Name = "Alface",
                        Price = 0.4,
                        Promotion = Core.Entities.Enum.Promotion.Light
                    },
                    new Ingredient()
                    {
                        Id = Guid.Parse("d26d3c66-ad94-4730-b040-d8842f3476b0"),
                        Name = "Hambúrguer de carne",
                        Price = 3,
                        Promotion = Core.Entities.Enum.Promotion.ExtraMeat
                    }
            };
        }



        [Fact]
        public void When_Call_GetPricePromotion_Passing_Ingredient_Entity_And_Amount_Less_Than_3()
        {
            //arrange
            var ingredient = CreateIngredientValid();
            var amount = 2;

            //act
            var result = ingredientService.GetPricePromotion(ingredient, amount);

            //assert
            Assert.Equal(result, (ingredient.Price * (amount - (int)(amount / 3))));
        }

        [Fact]
        public void When_Call_GetPricePromotion_Passing_Ingredient_Entity_And_Amount_Equals_3()
        {
            //arrange
            var ingredient = CreateIngredientValid();
            var amount = 3;

            //act
            var result = ingredientService.GetPricePromotion(ingredient, amount);

            //assert
            Assert.Equal(result, (ingredient.Price * (amount - (int)(amount / 3))));
        }

        [Fact]
        public void When_Call_GetPricePromotion_Passing_Ingredient_Entity_And_Amount_Greater_Than_3()
        {
            //arrange
            var ingredient = CreateIngredientValid();
            var amount = 4;

            //act
            var result = ingredientService.GetPricePromotion(ingredient, amount);

            //assert
            Assert.Equal(result, (ingredient.Price * (amount - (int)(amount / 3))));
        }

        [Fact]
        public void When_Call_GetPricePromotion_Passing_Ingredient_List_With_Bacon()
        {
            //arrange
            var ingredients = CreateIngredientListWithBaconValid();
            var total = 10;

            //act
            var result = ingredientService.GetPricePromotion(ingredients, total);

            //assert
            Assert.Equal(result, total);
        }

        [Fact]
        public void When_Call_GetPricePromotion_Passing_Ingredient_List_Without_Bacon()
        {
            //arrange
            var ingredients = CreateIngredientListWithoutBaconValid();
            var total = 10;

            //act
            var result = ingredientService.GetPricePromotion(ingredients, total);

            //assert
            Assert.Equal(result, total - ((10.0 / 100) * total));
        }
    }
}
