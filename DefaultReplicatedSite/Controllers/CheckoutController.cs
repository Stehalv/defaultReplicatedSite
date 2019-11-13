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
    [RoutePrefix("{webalias}/checkout")]
    public class CheckoutController : Controller
    {
        private CheckoutService _checkoutService = new CheckoutService();
        public ActionResult Index(CheckoutFlowType type = 0)
        {
            //All we do here is handle what flow to send them to. If none is specified, send them to shoppingcart. That should handle the correct redirect if nothing fishy is going on
            if(type == CheckoutFlowType.Shopping)
            {
                return RedirectToAction("Shopping");
            }
            else if(type == CheckoutFlowType.Enrollment)
            {
                return RedirectToAction("Enrollment");
            }
            else if(type == CheckoutFlowType.SimpleEnrollment)
            {
                
                return RedirectToAction("SimpleEnrollment");
            }
            else
            {
                return RedirectToAction("ShoppingCart");
            }
        }
        public ActionResult FlowError()
        {
            //Todo: Here we need to decide what to do when flows are messed up. Send them to a custom errorpage?
            return RedirectToAction("Index", "Home");
        }
        #region Cart
        public ActionResult ShoppingCart()
        {
            //Simple method to get the shoppingcart andmake it editable
            var model = _checkoutService.GetShoppingCart(OrderConfiguration, AutoOrderConfiguration);
            model.Order.IsEditable = true;
            model.AutoOrder.IsEditable = true;
            model.Type = _checkoutService.ShoppingCart.FlowType;
            return View(model);
        }
        #endregion

        #region Shopping
        //Here we handle all orderconfiguration logic
        //Todo: Make sure we handle logged in user pricing correctly
        private IOrderConfiguration OrderConfiguration = new UnitedStatesMarket().Configurations.Order;
        private IOrderConfiguration AutoOrderConfiguration = new UnitedStatesMarket().Configurations.AutoOrder;

        [Route("shopping")]
        public ActionResult Shopping(CheckoutSteps step = CheckoutSteps.CustomerInformation)
        {
            //If user switches flow after startied using one flow, and before checking out
            if (!_checkoutService.ValidatePropertyBags(CheckoutFlowType.Shopping))
            {
                return RedirectToAction("FlowError");
            }
            //Todo: Need to make sure we set Customer in CheckoutPropertybag if user is logged in
            
            //Set the current step, the vies and shoppingflow logic hadles the rest
            var model = new ShoppingFlow();
            model.CurrentStep = step;
            if (_checkoutService.ShoppingCart.HasItems)
            {
                //Cart will only be recalculated when going to shipping step, or when shipmethod has changed.
                var recalculate = false;
                if(model.CurrentStep == CheckoutSteps.Shipping)
                {
                    recalculate = true;
                }
                model.ShoppingCart = _checkoutService.GetShoppingCart(OrderConfiguration, AutoOrderConfiguration, recalculate);

                //If we are on last step, delete prpertybags
                if(model.CurrentStep == CheckoutSteps.CompleteCheckout)
                {
                    PropertyBagService.Delete(_checkoutService.CheckoutPropertyBag);
                    PropertyBagService.Delete(_checkoutService.ShoppingCart);
                }
                return View(model);
            }
            return RedirectToAction("ShoppingCart", "Checkout");
        }
        [HttpPost]
        [Route("submitshopping")]
        public ActionResult SubmitShoppingFlow(ShoppingFlow model)
        {
            //Submit the step completed, all logic for handling errors should be handled in the step logic.
            //Todo: Might want make the submitstep boolean, so we can decide what to do on errors.
            if(model.CurrentStep == CheckoutSteps.CustomerInformation)
            {
                model.InformationStep.SubmitStep();
            }
            if (model.CurrentStep == CheckoutSteps.Shipping)
            {
                model.ShippingStep.SubmitStep();
            }
            //Payment step is last step, so handle the submit checkout in this step
            if (model.CurrentStep == CheckoutSteps.Payment)
            {
                model.PaymentStep.SubmitStep();
                model.CheckoutCompleteStep.SubmitStep();
            }
            return RedirectToAction("Shopping", new { step = model.NextStep });
        }
        #endregion

        #region Enrollment

        private IOrderConfiguration EnrollmentConfiguration = new UnitedStatesMarket().Configurations.Enrollment;
        private IOrderConfiguration EnrollmentAutoOrderConfiguration = new UnitedStatesMarket().Configurations.EnrollmentAutoOrder;
        [Route("enrollment")]
        public ActionResult Enrollment(CheckoutSteps step = CheckoutSteps.CustomerInformation)
        {
            if (!_checkoutService.ValidatePropertyBags(CheckoutFlowType.Enrollment))
            {
                return RedirectToAction("FlowError");
            }
            var model = new EnrollmentFlow();
            model.CurrentStep = step;
            model.CurrentStep = step;
            if (_checkoutService.ShoppingCart.HasItems)
            {
                var recalculate = false;
                if (model.CurrentStep == CheckoutSteps.Shipping)
                {
                    recalculate = true;
                }
                model.ShoppingCart = _checkoutService.GetShoppingCart(EnrollmentConfiguration, EnrollmentAutoOrderConfiguration, recalculate);
                if (model.CurrentStep == CheckoutSteps.CompleteCheckout)
                {
                    PropertyBagService.Delete(_checkoutService.CheckoutPropertyBag);
                    PropertyBagService.Delete(_checkoutService.ShoppingCart);
                }
                return View(model);
            }
            return RedirectToAction("ShoppingCart", "Checkout");
        }
        [HttpPost]
        [Route("submitenrolment")]
        public ActionResult SubmitEnrollment(EnrollmentFlow model)
        {
            if (model.CurrentStep == CheckoutSteps.CustomerInformation)
            {
                model.InformationStep.SubmitStep();
            }
            if (model.CurrentStep == CheckoutSteps.Shipping)
            {
                model.ShippingStep.SubmitStep();
            }
            if (model.CurrentStep == CheckoutSteps.Payment)
            {
                model.PaymentStep.SubmitStep();
                model.CheckoutCompleteStep.SubmitStep();
            }
            return RedirectToAction("Enrollment", new { step = model.NextStep });
        }
        #endregion

        #region SimpleEnrollment
        [Route("simpleenrollment")]
        public ActionResult SimpleEnrollment(CheckoutSteps step = CheckoutSteps.CustomerInformation)
        {
            //Does not need to verify shoppingcart as this flow has no shopping
            var model = new SimpleEnrollmentFlow();
            model.CurrentStep = step;
            return View(model);
        }
        [HttpPost]
        [Route("submitsimpleenrollment")]
        public ActionResult SubmitSimpleEnrollment(SimpleEnrollmentFlow model)
        {
            
            if (model.CurrentStep == CheckoutSteps.CustomerInformation)
            {
                model.InformationStep.SubmitStep();
                model.CheckoutCompleteStep.SubmitStep();
            }
            if (model.CurrentStep == CheckoutSteps.CompleteCheckout)
            {
                PropertyBagService.Delete(_checkoutService.CheckoutPropertyBag);
                PropertyBagService.Delete(_checkoutService.ShoppingCart);
            }
            return RedirectToAction("SimpleEnrollment", new { step = model.NextStep });
        }
        #endregion

        #region Validations
        public JsonResult IsTaxIDAvailable([Bind(Prefix = "Customer.TaxID")]string TaxID)
        {
            return Json(_checkoutService.IsTaxIDAvailable(TaxID), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ajaxFunctions
        public JsonNetResult CountCart()
        {
            var Count = _checkoutService.ShoppingCart.OrderItems.Count();
            return new JsonNetResult(new
            {
                success = true,
                count = Count
            });
        }
        #endregion
    }
}