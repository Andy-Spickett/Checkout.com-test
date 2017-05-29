using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkout.ApiServices.Drinks.RequestModels
{
    public class BaseDrink
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
