using ChefSnacks.Core.Entities.Base;

namespace ChefSnacks.Core.Entities
{
    public class Ingredient : EntityBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
