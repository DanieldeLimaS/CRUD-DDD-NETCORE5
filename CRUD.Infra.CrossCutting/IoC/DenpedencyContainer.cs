using CRUD.Application.Interfaces;
using CRUD.Domain.Interfaces;
using CRUD.Infra.Data.Repositories;
using CRUD.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Infra.CrossCutting.IoC
{
    public static class DenpedencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IContatoRepository, ContatoRepository>();

            services.AddScoped<ICargoService, CargoServices>();
            services.AddScoped<ICargoRepository, CargoRepository>();
        }
    }

}
