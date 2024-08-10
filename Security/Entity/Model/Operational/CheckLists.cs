using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class CheckLists
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Calification_total { get; set; }
        public string State { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public DateTime? Deleted_At { get; set; }

        public ICollection<Qualifications> qualifications { get; set; }
        public ICollection<ReviewTechnicals> reviewTechnicals { get; set; }
    }
}
