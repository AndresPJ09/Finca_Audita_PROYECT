using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class FumigationsDto
    {
        public int Id { get; set; }
        public string DateFumigation { get; set; }
        public string QuiantityMix { get; set; }
        public int reviewTechnicals_id { get; set; }
        public string State { get; set; }
    }
}
