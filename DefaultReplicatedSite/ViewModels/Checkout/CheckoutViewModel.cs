using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.ViewModels
{
    public class CheckoutViewModel
    {
        public CheckoutViewModel()
        {
            ShoppingCart = new CartViewModel();
            Customer = new CRMCustomerContract();
        }
        public CheckoutViewModel(long id)
        {
            //Customer = Teqnavi.ServiceContext().GetCrmCustomerByCustomerId(id);
            Customer = null;
        }
        public CartViewModel ShoppingCart { get; set; }
        public CRMCustomerContract Customer { get; set; }
        public CheckoutShipping Shipping { get; set; }
        public CheckoutPayment Payment { get; set; }
        public int EnrollerID { get; set; }
        public CheckoutSteps CheckoutStep { get; set; }
        public CreateCustomerContract AddressContract { get; set; }
        public void test()
        {
            var service = new MakoLibrary.Services.MakoService(MakoLibrary.Services.Environment.Production.ToString());
            service.AddCustomer( new CreateCustomerContract { 
             
            });
        }
    }
}