using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class FumigationSuppliesDto
    {
        public int Id { get; set; }
        public string Doce { get; set; }
        public string Code { get; set; }
        public int supplies_id { get; set; }
        public int fumigation_id { get; set; }
        public string State { get; set; }
    }
}
