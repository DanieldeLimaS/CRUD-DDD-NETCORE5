using CRUD.Domain.Entities;
using CRUD.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infra.Data.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       
        public DbSet<CAD_contato> CAD_contato { get; set; }
        public DbSet<CAD_cargo> CAD_cargo { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
           
            builder.Entity<CAD_contato>(new CAD_contatoMapping().Configure);
            builder.Entity<CAD_cargo>(new CAD_cargoMapping().Configure);
            base.OnModelCreating(builder);
        }
       
        
    }
}
