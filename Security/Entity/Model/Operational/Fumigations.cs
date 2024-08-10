using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Fumigations
    {
        public int Id { get; set; }
        public string DateFumigation { get; set; }
        public string QuiantityMix { get; set; }
        public int reviewTechnicals_id { get; set; }
        public ReviewTechnicals reviewTechnicals { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<ReviewEvidences> reviewEvidences { get; set; }
        public ICollection<FumigationSupplies> fumigationSupplies { get; set; }
    }
}
