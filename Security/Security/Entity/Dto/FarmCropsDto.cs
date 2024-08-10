using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class FarmCropsDto
    {
        public int Id { get; set; }
        public string Crop_id { get; set; }
        public int Farm_id { get; set; }
        public int num_hectareas { get; set; }
        public string State { get; set; }
    }
}
