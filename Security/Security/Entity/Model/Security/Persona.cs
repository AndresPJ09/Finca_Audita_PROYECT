using Entity.Model.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Persona
    {
        public int Id { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string correo_electronico {  get; set; }
        public DateTime fecha_de_nacimiento { get; set; }
        public string genero {  get; set; }
        public string direccion { get; set; }
        public string tipo_de_documento {  get; set; }
        public string documento { get; set; }
        public Boolean State { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
        public int Ciudad_id { get; set; }
        public Ciudad ciudad { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; } 
        public DateTime? Deleted_at { get; set; }

    }
}
