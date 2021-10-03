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
        [Required(ErrorMessage ="Informe o Nome")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Não é permitido números e caracteres especiais para o Nome")]
        [MinLength(5,ErrorMessage ="Informe o nome e sobrenome")]
        [MaxLength(30,ErrorMessage ="Limite máximo de 30 caracteres para o Nome")]
        public string con_nome { get; set; }
        [Required(ErrorMessage = "Informe o Telefone")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Insira um telefone valido")]
        [MaxLength(16, ErrorMessage = "Limite máximo de 16 digitos para o Telefone")]
        public string con_telefone { get; set; }
        [Required(ErrorMessage ="Informe a Data de Nascimento")]
        [DataType(DataType.Date,ErrorMessage ="Insira uma data válida")]

        public DateTime con_dtNasc { get; set; }
        [Required(ErrorMessage ="Informe o Sexo")]
        public string con_sexo { get; set; }
        [Required(ErrorMessage ="Informe o Status")]
        public bool con_ativo { get; set; } 
        [Required(ErrorMessage ="Informe o Cargo")]
        public int car_id { get; set; }
        public string car_nome { get; set; }
    }
}
