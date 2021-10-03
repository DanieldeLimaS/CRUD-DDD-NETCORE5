using CRUD.Application.Interfaces;
using CRUD.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Services
{
    public class SexoServices : ISexoService

    {
        public List<SexoViewModel> ColecaoSexo()
        {
            var listaEstados = new List<SexoViewModel>()
            {
                new SexoViewModel(){ sex_sigla="M", sex_nome="Masculino"},
                new SexoViewModel(){ sex_sigla="F", sex_nome="Feminino"},
                new SexoViewModel(){ sex_sigla="N", sex_nome="Não informar"},
              
            };
            return listaEstados;
        }
    }
}
