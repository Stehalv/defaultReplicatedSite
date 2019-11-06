using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models
{
    public enum CheckoutSteps
    {
        ShoppingCart = 1,
        Information = 2,
        Shipping = 3,
        Payment = 4
    }
}