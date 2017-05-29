using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Checkout.ApiServices.Drinks.RequestModels;

namespace Checkout.ApiServices.Drinks.ResponseModels
{
    public class DrinksList
    {
        public List<BaseDrink> Drinks { get; set; }
    }
}
