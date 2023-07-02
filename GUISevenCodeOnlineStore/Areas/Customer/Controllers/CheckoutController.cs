using BLLSevenCodeOnlineStore.ModelRepositories.Admin;
using DALSevenCodeOnlineStore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GUISevenCodeOnlineStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CheckoutController : Controller
    {
        public IProductRepository _iProductRepository;
        private readonly SevenCodeOnlineStoreContext _context;
        public CheckoutController(SevenCodeOnlineStoreContext context)
        {

            _iProductRepository = new ProductRepository();
            _context = context;
        }


        public IActionResult Index()
        {
            List<Products> products = new List<Products>();
            products = HttpContext.Session.Get<List<Products>>("products");
            //if(products == null || products.Count == 0)
            //{
            //    return View(products);
            //}
            return View(products);
           // return View();
        }
        //============ show checkout ==========
        public IActionResult ShowDetailCheckout(int?id)
        {
            Products product = (Products)_iProductRepository.GetById(id);
            return View(product);
        }

    }
}
