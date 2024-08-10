using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class RolDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<UsuarioRol> usuarioRols { get; set; }
        public ICollection<RolVista> RolVistas { get; set; }
        public Boolean State { get; set; }
    }
}
