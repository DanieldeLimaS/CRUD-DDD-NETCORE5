using CRUD.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Application.Interfaces
{
    public interface ICargoService
    {
        Task<List<CargoViewModel>> ColecaoAsyncEFCore();

    }
}
