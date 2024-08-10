using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Evidences
    {
        public int Id { get; set; }
        public string Core { get; set; }
        public string Document { get; set; }
        public string State { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public DateTime? Deleted_At { get; set; }
        public ICollection<ReviewEvidences> ReviewEvidences { get; set; }
    }
}
