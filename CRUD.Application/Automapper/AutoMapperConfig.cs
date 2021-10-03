using AutoMapper;
using CRUD.Application.Automapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Application.Automapper
{
    public class AutoMapperConfig
    {
        public static void Configuration(IServiceCollection services)
        {
            var mapperconfig = new MapperConfiguration(config =>
            {
                config.AddProfile<CadastroProfile>();
            });
            services.AddSingleton(mapperconfig.CreateMapper());
        }
    }
}
