using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class UsuarioRol
    {
        public int Id { get; set;}
        public int Usuario_Id { get; set;}
        public int Rol_id {  get; set;}
        public Usuario usuario { get; set;}
        public Rol Rol { get; set;}
        public Boolean State { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
