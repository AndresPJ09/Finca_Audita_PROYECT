using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Supplies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string priece { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<FertilizationSupplies> fertilizationSupplies { get; set; }
        public ICollection<FumigationSupplies> fumigationSupplies { get; set; }
    }
}
