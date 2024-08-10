using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class FarmsDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Ciudad_id { get; set; }
        public int Usuario_id { get; set; }
        public string State { get; set; }
    }
}
