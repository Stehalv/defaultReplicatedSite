using DefaultReplicatedSite.ViewModels;
using DefaultReplicatedSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakoLibrary.Contracts;
using DefaultReplicatedSite.Services;
using LibraryCommon;

namespace DefaultReplicatedSite.Controllers
{
    public class CheckoutController : Controller
    {
        private CheckoutService _checkoutService = new CheckoutService();
        private IOrderConfiguration OrderConfiguration = new UnitedStatesMarket().Configurations.Order;
        public ActionResult Shopping(CheckoutSteps step = CheckoutSteps.Information)
        {
            var model = new ShoppingFlow();
            model.CurrentStep = step;
            if (_checkoutService.ShoppingCart.HasItems)
            {
                if (step == CheckoutSteps.Information)
                {
                    model.PreviousStep = CheckoutSteps.ShoppingCart;
                    model.CurrentStep = step;
                    model.NextStep = CheckoutSteps.Shipping;
                }
                if(step == CheckoutSteps.Shipping)
                {
                    model.PreviousStep = CheckoutSteps.Information;
                    model.CurrentStep = step;
                    model.NextStep = CheckoutSteps.Payment;
                }
                if (step == CheckoutSteps.Payment)
                {
                    model.CurrentStep = step;
                    model.NextStep = CheckoutSteps.OrderCompleted;
                }
                var recalculate = false;
                if(model.CurrentStep == CheckoutSteps.Shipping)
                {
                    recalculate = true;
                }
                model.ShoppingCart = _checkoutService.GetShoppingCart(OrderConfiguration, OrderConfiguration, recalculate);
                return View(model);
            }
            return RedirectToAction("Index", "Shopping");
        }
        [HttpPost]
        public ActionResult SubmitShoppingFlow(ShoppingFlow model)
        {
            model.InformationStep.SubmitStep();
            model.ShippingStep.SubmitStep();
            model.PaymentStep.SubmitStep();
            return RedirectToAction("Index", new { step = model.NextStep });
        }
    }
}