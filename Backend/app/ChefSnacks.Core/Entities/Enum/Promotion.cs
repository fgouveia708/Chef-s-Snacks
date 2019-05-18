using ChefSnacks.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ChefSnacks.Core.Entities.Enum
{
    public enum Promotion
    {
        [Promotion(Name = "Light", Description = "PROMOÇÃO VIVA MAIS: Por escolher lanche light você ganhou 10% de desconto.")]
        Light = 1,

        [Promotion(Name = "Muito Carne", Description = "PROMOÇÃO EXTRA DE CARNE: Compre 3 e pague 2")]
        ExtraMeat = 2,

        [Promotion(Name = "Muito Queijo", Description = "PROMOÇÃO EXTRA DE QUEIJO: Compre 3 e pague 2")]
        ExtraCheese = 3

    }

    public class PromotionAttribute : EnumAttribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
