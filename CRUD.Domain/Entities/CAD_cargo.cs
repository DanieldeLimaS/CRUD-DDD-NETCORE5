using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Entities
{
    public class CAD_cargo
    {
        public CAD_cargo()
        {
            cAD_contato = new HashSet<CAD_contato>();
        }
        public int car_id { get; set; }
        public string car_nome { get; set; }
        public virtual ICollection<CAD_contato> cAD_contato { get; set; }
    }
}
