using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class ReviewTechnicalsDto
    {
        public int Id { get; set; }
        public string Date_review { get; set; }
        public string Code { get; set; }
        public string Observation { get; set; }
        public int farm_id { get; set; }
        public int Tecnico_id { get; set; }
        public int checkLists_id { get; set; }
        public string State { get; set; }
    }
}
