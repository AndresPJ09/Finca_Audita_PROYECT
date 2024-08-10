using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class AssessmentCriteria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rating_range { get; set; }
        public string Type_criterian { get; set; }
        public string State { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public DateTime? Deleted_At { get; set; }

        public ICollection<Qualifications> Qualifications { get; set; }
    }
}
