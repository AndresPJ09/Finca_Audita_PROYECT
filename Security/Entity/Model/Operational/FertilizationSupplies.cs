using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class FertilizationSupplies
    {
        public int Id { get; set; }
        public string Dose { get; set; }
        public int supplies_id { get; set; }
        public Supplies supplies { get; set; }
        public int fertilization_id { get; set; }
        public Fertilization fertilization { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
