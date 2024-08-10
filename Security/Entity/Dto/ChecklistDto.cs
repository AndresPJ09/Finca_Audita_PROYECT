using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class ChecklistDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Calification_total { get; set; }
        public string State { get; set; }
    }
}
