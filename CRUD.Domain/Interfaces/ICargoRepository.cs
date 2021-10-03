using CRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Interfaces
{
    public interface ICargoRepository
    {
        List<CAD_cargo> ColecaoEFCore();
    }
}
