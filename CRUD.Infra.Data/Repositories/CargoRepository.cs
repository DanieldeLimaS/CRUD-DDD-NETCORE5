using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces;
using CRUD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<List<CAD_cargo>> ColecaoEFCore()
        {
            return await context.CAD_cargo.ToListAsync();
        }
    }
}
