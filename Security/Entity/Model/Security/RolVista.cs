using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class RolVista
    {
        public int Id { get; set; }
        public int Rol_id{ get; set; }
        public int Vista_id { get; set; }
        public Rol Rol { get; set; }
        public Vista Vista { get; set; }
        public Boolean State { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }

    }


}
