using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        /// <summary>
        /// classe auxiliar do controlador Seller.
        /// </summary>
        
        //depedencia do banco de dados.
        private readonly SalesWebMvcContext _context;

        //criação de construtor.
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

       //metodo para retornar as informações da Class "Seller" em forma de lista.
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        //metodo para adicionar o "obj" no banco de dados.
        public void Insert(Seller obj)
        {
            //associar o primeiro departamento no vendendor
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
