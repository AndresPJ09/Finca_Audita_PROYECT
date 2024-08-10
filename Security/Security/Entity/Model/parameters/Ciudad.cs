using Entity.Model.Operational;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.parameters
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Departamento_id { get; set; }
        public Departamento departamento { get; set; }
        public bool State { get; set; }
        public ICollection<Persona> persona { get; set; }
        public ICollection<Farms> farms { get; set; }
        public ICollection<Pais> pais { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
