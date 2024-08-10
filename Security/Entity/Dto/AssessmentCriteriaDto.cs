using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class AssessmentCriteriaDto
    {
        public int Id { get; set; }
        public string Observation { get; set; }
        public string Qualification_criteria { get; set; }
        public int Assessment_criterian_id { get; set; }
        public int Checklist_id { get; set; }
        public string State { get; set; }
    }
}
