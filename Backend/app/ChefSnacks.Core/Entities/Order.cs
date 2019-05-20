using System;
using System.Collections.Generic;
using System.Text;

namespace ChefSnacks.Core.Entities
{
    public class Order
    {
        public Guid IdSnack { get; set; }
        public int Amount { get; set; }
    }
}
