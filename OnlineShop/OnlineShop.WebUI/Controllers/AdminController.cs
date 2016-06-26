using OnlineShop.Domain.Abstract;
using OnlineShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.Porducts);
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deleteProduct = repository.DeleteProduct(productId);

            if (deleteProduct != null)
            {
                TempData["message"] = string.Format("{0} zosał usunięty", deleteProduct.Name);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Porducts.FirstOrDefault(p => p.ProductId == productId);

            return View(product);
        }

        public ViewResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} został dodany", product.Name);

                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} został edytowany", product.Name);

                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
    }
}