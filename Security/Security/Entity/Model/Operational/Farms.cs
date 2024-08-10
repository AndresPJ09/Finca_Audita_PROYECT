using Entity.Model.parameters;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Farms
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Ciudad_id { get; set; }
        public Ciudad ciudad { get; set; }
        public int Usuario_id { get; set; }
        public Usuario usuario { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<FarmCrops> farmCrops { get; set; }
        public ICollection<ReviewTechnicals> reviewTechnicals { get; set; }
    }
}
