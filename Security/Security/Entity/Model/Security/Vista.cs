using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Vista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ruta { get; set; }
        public int Modulo_id { get; set; }
        public Modulo Modulo { get; set; }
        public Boolean State { get; set; }
        public ICollection<RolVista> RolVistas { get; set; } = new List<RolVista>();
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }


    }
}
