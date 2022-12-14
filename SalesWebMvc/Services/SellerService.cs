using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        //metodo para adicionar o "obj"(dados do vendendor) no banco de dados.
        public void Insert(Seller obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }

        //metodo para retorna o vendendor que tem o ID, se não tiver o ID retorna NULL
        //metodo Include(obj => obj.Department), para retorna o departamento do vendendor.
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        //metodo para remoção do vendedor 
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
