using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class FertilizationSuppliesDto
    {
        public int Id { get; set; }
        public string Dose { get; set; }
        public int supplies_id { get; set; }
        public int fertilization_id { get; set; }
        public string State { get; set; }
    }
}
