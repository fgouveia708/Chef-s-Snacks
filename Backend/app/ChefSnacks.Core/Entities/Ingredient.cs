using ChefSnacks.Core.Entities.Base;
using ChefSnacks.Core.Entities.Enum;

namespace ChefSnacks.Core.Entities
{
    public class Ingredient : EntityBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Promotion Promotion { get; set; }
    }
}
