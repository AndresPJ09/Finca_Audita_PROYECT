using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class UsuarioRolDto
    {
        public int Id;
        public int Usuario_Id { get; set; }
        public int Rol_id { get; set; }
        public Boolean State { get; set; }
    }
}
