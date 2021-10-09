using System;

namespace CRUD.Domain.DTOs
{
    public class ContatoDTO
    {
        public int con_id { get; set; }
        public string con_nome { get; set; }
        public string con_telefone { get; set; }
        public DateTime con_dtNasc { get; set; }
        public string con_sexo { get; set; }
        public bool con_ativo { get; set; } = true;
        public int car_id { get; set; }
        public string car_nome { get; set; }
    }
}
