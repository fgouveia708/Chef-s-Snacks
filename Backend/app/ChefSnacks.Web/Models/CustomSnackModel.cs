using System;
using System.Collections.Generic;

namespace ChefSnacks.Web.Models
{
    public class CustomSnackModel
    {
        public IList<Order> Orders { get; set; }
    }

    public class Order
    {
        public Guid IdSnack { get; set; }
        public int Amount { get; set; }
    }
}
