using CRUD.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Application.Interfaces
{
    public interface IContatoService
    {
        Task<(bool, string)> InserirAsyncEFCore(ContatoViewModel contatoViewModel);
        Task<(bool, string)> AtualizarAsyncEFCore(ContatoViewModel contatoViewModel);
        Task<(bool, string)> ExcluirAsyncEFCore(ContatoViewModel contatoViewModel);
        Task<List<ContatoViewModel>> ColecaoAsyncEFCore(string pesquisa="");

        Task<ContatoViewModel> ObjetoPorIdAsyncEFCore(int id);

    }
}
