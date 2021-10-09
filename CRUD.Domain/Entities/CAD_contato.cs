using System;

namespace CRUD.Domain.Entities
{
    public class CAD_contato
    {
        
        public int con_id { get; set; }
        public string con_nome { get; set; }
        public string con_telefone { get; set; }
        public DateTime con_dtNasc { get; set; }
        public string con_sexo { get; set; }
        public bool con_ativo { get; set; }
        public  int car_id { get; set; }
        public virtual CAD_cargo cAD_cargo { get; set; }

        
    }
}
