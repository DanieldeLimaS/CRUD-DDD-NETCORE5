using AutoMapper;
using CRUD.Application.ViewModels;
using CRUD.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Application.Automapper
{
    public class AutoMapperConfig
    {
        public static void Configuration(IServiceCollection services)
        {
            var mapperconfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CAD_contato, ContatoViewModel>();
                config.CreateMap<ContatoViewModel, CAD_contato>();

                config.CreateMap<CAD_cargo, CargoViewModel>();
                config.CreateMap<CargoViewModel, CAD_cargo>();
            });
            services.AddSingleton(mapperconfig.CreateMapper());
        }
    }
}
