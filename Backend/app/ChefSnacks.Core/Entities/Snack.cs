using ChefSnacks.Core.Entities.Base;
using System.Collections.Generic;

namespace ChefSnacks.Core.Entities
{
    public class Snack : EntityBase
    {
        public string Name { get; set; }
        public IList<Ingredient> Ingredients { get; set; }
    }
}
