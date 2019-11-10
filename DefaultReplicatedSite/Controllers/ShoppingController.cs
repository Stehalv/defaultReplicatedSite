using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MakoLibrary.Contracts;
using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.Services;
using DefaultReplicatedSite.ViewModels;
using System.Linq;

namespace DefaultReplicatedSite.Controllers
{

    [RoutePrefix("{webalias}/products")]
    public class ShoppingController : Controller
    {
        private ItemService _itemService = new ItemService();
        private IOrderConfiguration OrderConfiguration = new UnitedStatesMarket().Configurations.Order;
        private IOrderConfiguration AutoOrderConfiguration = new UnitedStatesMarket().Configurations.AutoOrder;
        private ShoppingCartPropertyBag _shoppingCart { get; set; }
        public ShoppingCartPropertyBag ShoppingCart
        {
            get
            {
                if(_shoppingCart == null)
                {
                    _shoppingCart = PropertyBagService.Get<ShoppingCartPropertyBag>(Settings.Company.CookieName + "_ShoppingCart");
                }
                return _shoppingCart;
            }
        }
        // GET: Shopping
        [Route("all")]
        public ActionResult Index()
        {
            var model = new WebCategoryViewModel
            {
                ChildCategories = new List<WebCategory>
                {
                    new WebCategory
                    {
                        Name = "Kristals Gemstone Skincare",
                        MediumImage = "https://i1.wp.com/luxxium.net/wp-content/uploads/2019/04/unnamed.jpg?w=760&amp;ssl=1",
                        WebCategoryId = 1,
                        Descr = "KRISTALS<br> GEMSTONE SKINCARE"
                    },
                    new WebCategory
                    {
                        Name = "TechTure advanced skincare techology",
                        MediumImage = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/04/TECH.png?w=760&amp;ssl=1",
                        WebCategoryId = 2,
                        Descr = "TECHTURE ADVANCED <br>SKINCARE TECHNOLOGY"
                    },
                }
            };
            return View(model);
        }
        [Route("category/{category}")]
        public ActionResult CategoryList(int category)
        {
            var model = new WebCategoryViewModel();
            model.ChildCategories = _itemService.GetWebCategories(new WebCategoryRequest()).Select(c => new WebCategory { 
                WebCategoryId = c.WebCategoryId,
                Descr = c.Descr,
                MediumImage = c.MediumImage
            }).ToList();
            return View(model);
        }

        [Route("{category}")]
        public ActionResult CategoryProductList(int category)
        {
            var model = new WebCategoryViewModel();
            model.Items = _itemService.GetItems(new ItemRequest(OrderConfiguration));
            return View(model);
        }
        #region AjaxRequests
        public ActionResult AddItemToOrder(ShoppingCartItem item)
        {
            if(ShoppingCart.FlowType != CheckoutFlowType.Shopping)
            {
                PropertyBagService.Delete(ShoppingCart);
            }
            ShoppingCart.FlowType = CheckoutFlowType.Shopping;
            ShoppingCart.OrderItems.Add(item);
            PropertyBagService.Update(ShoppingCart);
            return new JsonNetResult(new
            {
                success = true
            });
        }

        [HttpPost]
        public ActionResult AddItemToutoOrder(ShoppingCartItem item)
        {
            if (ShoppingCart.FlowType != CheckoutFlowType.Shopping)
            {
                PropertyBagService.Delete(ShoppingCart);
            }
            ShoppingCart.FlowType = CheckoutFlowType.Shopping;
            ShoppingCart.AutoOrderItems.Add(item);
            PropertyBagService.Update(ShoppingCart);
            return new JsonNetResult(new
            {
                success = true
            });
        }
        #endregion
    }
}