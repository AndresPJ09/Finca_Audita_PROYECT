using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class ReviewEvidencesDto
    {
        public int Id { get; set; }
        public int Evidence_id { get; set; }
        public int ReviewTechnicals_id { get; set; }
        public string State { get; set; }
    }
}
