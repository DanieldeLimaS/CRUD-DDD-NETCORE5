using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces;
using CRUD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Infra.Data.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private AppDbContext context;
        public CargoRepository(AppDbContext _context)
        {
            context = _context;
        }
        public  List<CAD_cargo> ColecaoEFCore()
        {
            return  context.CAD_cargo.ToList();
        }
    }
}
