using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Entities
{
    public class CAD_contato
    {
        public CAD_contato()
        {
            cAD_cargo = new CAD_cargo();
        }
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
