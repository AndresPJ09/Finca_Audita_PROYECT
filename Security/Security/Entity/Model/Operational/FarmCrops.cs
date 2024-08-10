using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class FarmCrops
    {
        public int Id { get; set; }
        public string Crop_id { get; set; }
        public Crops cropds { get; set; }
        public int Farm_id { get; set; }
        public Farms farms { get; set; }
        public int num_hectareas { get; set; }
        public string State { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public DateTime? Deleted_At { get; set; }
    }
}
