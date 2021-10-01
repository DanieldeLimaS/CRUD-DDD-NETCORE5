using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CRUD.Infra.Data.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=CRUD;uid=sa;pwd=1234;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
