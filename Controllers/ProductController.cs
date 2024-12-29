using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;
using System.Collections;


namespace ProductManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private IProductService ProductService;


        public ProductController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(string title,string description,int quantity,double price)
        {
            Product product =new Product(title, description, quantity, price);

            if (ModelState.IsValid)
            {
                ProductService.AddProduct(product);
                return RedirectToAction("GetAllProduct");
            }
            return View(product);
        }

        public IActionResult GetAllProduct()
        {
            IEnumerable products = ProductService.GetAllProduct();
            return View(products);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            ProductService.DeleteProduct(id);
            return RedirectToAction("GetAllProduct");
        }

        public IActionResult EditProduct(int id)
        {
            var product = ProductService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            ProductService.UpdateProduct(product);
            return RedirectToAction("GetAllProduct");
        }

    }
}
