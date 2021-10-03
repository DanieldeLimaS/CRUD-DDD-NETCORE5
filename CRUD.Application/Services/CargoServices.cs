using AutoMapper;
using CRUD.Application.Interfaces;
using CRUD.Application.ViewModels;
using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Services
{
    public class CargoServices : ICargoService
    {

        public ICargoRepository cargoRepository;
        private readonly IMapper mapper;
        public CargoServices(ICargoRepository _cargoRepository, IMapper _mapper)
        {
            cargoRepository = _cargoRepository;
            mapper = _mapper;
        }
        public List<CargoViewModel> ColecaoEFCore()
        {
            return mapper.Map<List<CargoViewModel>>( cargoRepository.ColecaoEFCore());
        }
    }
}
