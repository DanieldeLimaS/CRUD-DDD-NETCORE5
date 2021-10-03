using AutoMapper;
using CRUD.Application.ViewModels;
using CRUD.Domain.DTOs;
using CRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Automapper.Profiles
{
    public class CadastroProfile: Profile
    {
        public CadastroProfile()
        {
            CreateMap<CAD_contato, ContatoViewModel>();
            CreateMap<ContatoViewModel, CAD_contato>();

            CreateMap<CAD_cargo, CargoViewModel>();
            CreateMap<CargoViewModel, CAD_cargo>();

            CreateMap<ContatoDTO, ContatoViewModel>();
        }
    }
}
