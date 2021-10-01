using CRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.ViewModels
{
    public class ContatoViewModel
    {
        public int con_id { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        public string con_nome { get; set; }
        public string con_telefone { get; set; }
        public DateTime con_dtNasc { get; set; }
        public string con_sexo { get; set; }
        public bool con_ativo { get; set; }
        public int car_id { get; set; }
        public string car_nome { get; set; }
    }
}
