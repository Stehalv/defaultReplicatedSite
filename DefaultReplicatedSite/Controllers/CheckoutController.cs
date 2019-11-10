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
        #region Cart
        public ActionResult Cart()
        {
            var model = _checkoutService.GetShoppingCart(OrderConfiguration, AutoOrderConfiguration);
            return View(model);
        }
        #endregion

        #region Shopping
        private IOrderConfiguration OrderConfiguration = new UnitedStatesMarket().Configurations.Order;
        private IOrderConfiguration AutoOrderConfiguration = new UnitedStatesMarket().Configurations.AutoOrder;

        [Route("shopping")]
        public ActionResult Shopping(CheckoutSteps step = CheckoutSteps.CustomerInformation)
        {
            _checkoutService.ValidatePropertyBags(CheckoutFlowType.Shopping);
            if(Identity.Customer != null)
            {
                //Set Customer
            }
            var model = new ShoppingFlow();
            model.CurrentStep = step;
            if (_checkoutService.ShoppingCart.HasItems)
            {
                if (step == CheckoutSteps.CustomerInformation)
                {
                    model.CurrentStep = step;
                }
                if(step == CheckoutSteps.Shipping)
                {
                    model.CurrentStep = step;
                }
                if (step == CheckoutSteps.Payment)
                {
                    model.CurrentStep = step;
                }
                var recalculate = false;
                if(model.CurrentStep == CheckoutSteps.Shipping)
                {
                    recalculate = true;
                }
                model.ShoppingCart = _checkoutService.GetShoppingCart(OrderConfiguration, AutoOrderConfiguration, recalculate);
                if(model.CurrentStep == CheckoutSteps.CompleteCheckout)
                {
                    PropertyBagService.Delete(_checkoutService.CheckoutPropertyBag);
                    PropertyBagService.Delete(_checkoutService.ShoppingCart);
                }
                return View(model);
            }
            return RedirectToAction("Index", "Shopping");
        }
        [HttpPost]
        [Route("submitshopping")]
        public ActionResult SubmitShoppingFlow(ShoppingFlow model)
        {
            if(model.CurrentStep == CheckoutSteps.CustomerInformation)
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
            return RedirectToAction("Shopping", new { step = model.NextStep });
        }
        #endregion

        #region Enrollment

        private IOrderConfiguration EnrollmentConfiguration = new UnitedStatesMarket().Configurations.Enrollment;
        private IOrderConfiguration EnrollmentAutoOrderConfiguration = new UnitedStatesMarket().Configurations.EnrollmentAutoOrder;
        [Route("enrollment/{step}")]
        public ActionResult Enrollment(CheckoutSteps step = CheckoutSteps.CustomerInformation)
        {
            _checkoutService.ValidatePropertyBags(CheckoutFlowType.Enrollment);
            var model = new EnrollmentFlow();
            model.CurrentStep = step;
            if (_checkoutService.ShoppingCart.HasItems)
            {
                if (step == CheckoutSteps.CustomerInformation)
                {
                    model.CurrentStep = step;
                }
                if (step == CheckoutSteps.Shipping)
                {
                    model.CurrentStep = step;
                }
                if (step == CheckoutSteps.Payment)
                {
                    model.CurrentStep = step;
                }
                if (step == CheckoutSteps.CompleteCheckout)
                {
                    model.CurrentStep = step;
                }
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
            return RedirectToAction("Index", "Shopping");
        }
        [HttpPost]
        [Route("submitenrolment/{step}")]
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
        [Route("simpleenrollment/{step}")]
        public ActionResult SimpleEnrollment(CheckoutSteps step = CheckoutSteps.CustomerInformation)
        {
            _checkoutService.ValidatePropertyBags(CheckoutFlowType.SimpleEnrollment);
            var model = new SimpleEnrollmentFlow();
            model.CurrentStep = step;
            if (step == CheckoutSteps.CustomerInformation)
            {
                model.CurrentStep = step;
            }
            if (step == CheckoutSteps.CompleteCheckout)
            {
                model.CurrentStep = step;
            }
            return View(model);
        }
        [HttpPost]
        [Route("submitsimpleenrollment/{step}")]
        public ActionResult SubmitSimpleEnrollment(SimpleEnrollmentFlow model)
        {
            if (model.CurrentStep == CheckoutSteps.CustomerInformation)
            {
                model.InformationStep.SubmitStep();
                model.CheckoutCompleteStep.SubmitStep();
            }
            return RedirectToAction("SimpleEnrollment", new { step = model.NextStep });
        }
        #endregion
    }
}