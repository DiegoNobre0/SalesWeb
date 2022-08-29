using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DeparmentService
    {
        //depedencia do banco de dados.
        private readonly SalesWebMvcContext _context;

        //criação de construtor.
        public DeparmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //metodo para retornar todos os departamentos ordenados por nome.
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
