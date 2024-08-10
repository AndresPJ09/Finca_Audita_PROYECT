using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class ReviewEvidences
    {
        public int Id { get; set; }
        public int Evidence_id { get; set; }
        public Evidences Evidences { get; set; }
        public int ReviewTechnicals_id { get; set; }
        public ReviewTechnicals reviewTechnicals { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
