using AutoMapper;
using CRUD.Application.Interfaces;
using CRUD.Application.ViewModels;
using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace CRUD.Application.Services
{
    public class ContatoService : IContatoService
    {
        public IContatoRepository contatoRepository;
        private readonly IMapper mapper;
        public ContatoService(IContatoRepository _contatoRepository, IMapper _mapper)
        {
            contatoRepository = _contatoRepository;
            mapper = _mapper;
        }
        public async Task<List<ContatoViewModel>> ColecaoAsyncEFCore(string pesquisa = "")
        {
            List<ContatoViewModel> Contato = mapper.Map<List<ContatoViewModel>>(await contatoRepository.ColecaoEFCore(pesquisa));
            return Contato;
        }

        public async Task<(bool, string)> InserirAsyncEFCore(ContatoViewModel contatoViewModel)
        {
            Validator.ValidateObject(contatoViewModel, new ValidationContext(contatoViewModel), true);
            CAD_contato cAD_contato = mapper.Map<CAD_contato>(contatoViewModel);
            return await contatoRepository.InserirEFCore(cAD_contato);
        }

        public async Task<(bool, string)> AtualizarAsyncEFCore(ContatoViewModel contatoViewModel)
        {
           
            CAD_contato cAD_contato = mapper.Map<CAD_contato>(contatoViewModel);
            return await contatoRepository.AtualizarObjetoEFCore(cAD_contato);
        }

        public async Task<(bool,string)> ExcluirAsyncEFCore(ContatoViewModel contatoViewModel)
        {
            return await contatoRepository.ExcluirObjetoEFCore(contatoViewModel.con_id);
        }

        public async Task<ContatoViewModel> ObjetoPorIdAsyncEFCore(int id)
        {
            return mapper.Map<ContatoViewModel>(await contatoRepository.ObjetoPorIdEFCore(id));
        }
    }
}
