using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Qualifications
    {
        public int Id { get; set; }
        public string Observation { get; set; }
        public string Qualification_criteria { get; set; }
        public int Assessment_criterian_id { get; set; }
        public AssessmentCriteria assessment_criterian { get; set; }
        public int Checklist_id { get; set; }
        public CheckLists checklist{ get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


    }
}
