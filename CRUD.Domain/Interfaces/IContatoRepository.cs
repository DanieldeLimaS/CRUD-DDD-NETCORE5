using CRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Interfaces
{
    public interface IContatoRepository
    {
        Task<List<CAD_contato>> ColecaoEFCore();
        Task<CAD_contato> ObjetoPorIdEFCore(int id);
        Task<(bool, string)> ExcluirObjetoEFCore(int id);
        Task<(bool, string)> AtualizarObjetoEFCore(CAD_contato cAD_contato);
        Task<(bool, string)> InserirEFCore(CAD_contato cAD_contato);

    }
}
