using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class RolVistaDto
    {
        public int Id { get; set; }
        public int Rol_id { get; set; }
        public int Vista_id { get; set; }
        public Boolean State { get; set; }
    }
}
