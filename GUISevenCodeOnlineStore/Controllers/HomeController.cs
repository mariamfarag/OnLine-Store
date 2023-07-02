using BLLSevenCodeOnlineStore.ModelRepositories.Admin;
using DALSevenCodeOnlineStore;
using GUISevenCodeOnlineStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GUISevenCodeOnlineStore.Controllers
{
    

    public class HomeController : Controller
    {
        public IProductRepository _iProductRepository;
        private readonly SevenCodeOnlineStoreContext _context;
        private readonly ILogger<HomeController> _logger;

        private const int PageSize = 9;

        public HomeController(ILogger<HomeController> logger , SevenCodeOnlineStoreContext context)
        {
            _logger = logger;
            _iProductRepository = new ProductRepository();
            _context = context;
        }

        public IActionResult Index2()
        {
            return View();
        }

        //public IActionResult Index()
        //{
        //    return View(_iProductRepository.GetByAll());
        //  //  return View();
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        //--------------------------
        public IActionResult Index(string SearchString, int page = 1)
        {

            if (string.IsNullOrEmpty(SearchString) || string.IsNullOrWhiteSpace(SearchString))
            {
                var result = _iProductRepository.GetAll(PageSize, page);
                ViewBag.PaginationData = new PaginationViewModel
                {
                    CurrentPage = result.CurrentPage,
                    TotalPages = result.TotalPages
                };
                return View(result.products);
            }
            else
            {
                var result = _iProductRepository.Serch(SearchString, PageSize, page);
                ViewBag.PaginationData = new PaginationViewModel
                {
                    CurrentPage = result.CurrentPage,
                    TotalPages = result.TotalPages
                };
                return View(result.products);
            }
        }
        [HttpGet]
        public IActionResult Autocomplete(string term)
        {
            var results = _iProductRepository.AutoComplete(term);
            return Json(results);
        }


        //--------------------------------
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
