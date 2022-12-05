using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace FirstWebApp.Controllers
{
    public class ProductsController : Controller
    {

        private IEnumerable<ProductsViewModel> products = new List<ProductsViewModel>()
        {
            new ProductsViewModel
            {
                Name ="Laptop",
                Price = 320,
                Id = 1
            },
             new ProductsViewModel
            {
                Name ="COD",
                Price = 20,
                Id = 2
            },
              new ProductsViewModel
            {
                Name ="Mouse",
                Price = 12,
                Id = 3
            },
        };
        [ActionName("My-Products")]
        public IActionResult All()
        {
            ViewBag.Products = products;
            return View(this.products);
        }

        public IActionResult ById(int id)
        {
           var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return BadRequest();
            }
            return View(product);
        }

        public IActionResult AllAsJSON()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return Json(products,options);
        }

        public IActionResult AllAsText()
        {
           StringBuilder sb = new StringBuilder();

            foreach (var product in products)
            {
                sb.AppendLine($"{product.Name} {product.Price} - {product.Id}");
            }

            return Content(sb.ToString());
        }
    }
}
