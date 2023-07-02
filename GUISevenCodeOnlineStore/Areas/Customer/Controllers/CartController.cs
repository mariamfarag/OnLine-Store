using BLLSevenCodeOnlineStore.BaseRepository;
using BLLSevenCodeOnlineStore.ModelRepositories.Admin;
using DALSevenCodeOnlineStore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GUISevenCodeOnlineStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
      
        public IProductRepository _iProductRepository;
        private readonly SevenCodeOnlineStoreContext _context;
        public CartController(SevenCodeOnlineStoreContext context)
        {
       
            _iProductRepository = new ProductRepository();
            _context = context;
        }
 
        public IActionResult Index()
        {
            List<Products> products = new List<Products>();
            products = HttpContext.Session.Get<List<Products>>("products");
            return View(products);
        }

        [HttpGet]
        public IActionResult addtoCart(int? id)
        {
            List<Products> products = new List<Products>();
            if (id == null)
            {
                return NotFound();
            }
            Products product =(Products) _iProductRepository.GetById(id);
            products = HttpContext.Session.Get<List<Products>>("products") ;
            if (products == null)
            {
                products = new List<Products>();
            }
            products.Add(product);
            HttpContext.Session.Set("products", products);
            if (products == null)
            {
                products = new List<Products>();
            }
            return RedirectToAction("Index", products);
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            Products product = (Products)_iProductRepository.GetById(id);
            return View(product);
        }
        [HttpGet]
        public IActionResult delete(int ?id)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction("Index");
        }



    }
}
