using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        
        /// <summary>
        ///criação do controller de vendendores manualmente 
        /// </summary>

        //depedencia do banco de dados 
        private readonly SellerService _sellerService;

        //criação do construtor 
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        //ação para a visualição em lista dos vendendores..
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        //ação para adicionar um novo vendendor.
        public IActionResult Create()
        {
            return View();
        }
        

        //ação para adicionar o novo vendendor no banco de dados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        

        
    }
}
