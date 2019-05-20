using ChefSnacks.Core.Attributes;

namespace ChefSnacks.Core.Entities.Enum
{
    public enum Promotion
    {
        [Promotion(Name = "Nenhuma", Description = "")]
        None = 0,

        [Promotion(Name = "Light", Description = "PROMOÇÃO VIVA MAIS: Por escolher lanche light você ganhou 10% de desconto.")]
        Light = 1,

        [Promotion(Name = "Muita Carne", Description = "PROMOÇÃO EXTRA DE CARNE: Compre 3 e pague 2")]
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
