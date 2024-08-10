using Entity.Model.Security;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class ReviewTechnicals
    {
        public int Id { get; set; }
        public string Date_review { get; set; }
        public string Code { get; set; }
        public string Observation { get; set; }
        public int farm_id { get; set; }
        public Farms farms { get; set; }
        public int Tecnico_id { get; set; }
        public int checkLists_id { get; set; }
        public CheckLists checkListsd { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Fertilization> fertilization { get; set; }
        public ICollection<Fumigations> fumigations { get; set; }
        public ICollection<ReviewEvidences> reviewEvidences { get; set; }
    }
}
