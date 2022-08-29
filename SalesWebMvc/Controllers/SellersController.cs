using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        
        /// <summary>
        ///criação do controller de vendendores manualmente 
        /// </summary>

        //depedencia do banco de dados 
        private readonly SellerService _sellerService;
        //depedencia da class "DeparmentService"
        private readonly DeparmentService _deparmentService;

        //criação do construtor 
        public SellersController(SellerService sellerService, DeparmentService deparmentService)
        {
            _sellerService = sellerService;
            _deparmentService = deparmentService;
        }

        //ação para a visualição em lista dos vendendores..
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        //ação para abrir o formulario para adicionar um novo vendendor.
        public IActionResult Create()
        {   //buscar todos os dados de departamento.
            var departments = _deparmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }
        

        //ação para adicionar o novo vendendor no banco de dados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        

        
    }
}
