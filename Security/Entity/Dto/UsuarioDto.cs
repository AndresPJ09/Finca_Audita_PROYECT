using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int Persona_id { get; set; }
        public ICollection<UsuarioRol> usuarioRols { get; set; }
        public Boolean State { get; set; }
    }
}
