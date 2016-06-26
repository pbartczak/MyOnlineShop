using OnlineShop.Domain.Abstract;
using OnlineShop.Domain.Entites;
using OnlineShop.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IProductRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ViewResult Checkout()
        {
            return View(new ShoppingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(ShoppingDetails shippingDetails)
        {
            if (GetCart().Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Nic nie wybrałeś");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(GetCart(), shippingDetails);
                GetCart().Clear();
                
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Porducts.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Porducts.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}