using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class MenuDto
    {
        public UsuarioDto Usuario { get; set; }
        public List<RolDto> Roles { get; set; }
        public List<VistaDto> Vistas { get; set; }
    }
}
