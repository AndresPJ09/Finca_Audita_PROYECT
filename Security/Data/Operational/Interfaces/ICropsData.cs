using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interfaces
{
    public interface ICropsData
    {
        public Task Delete(int id);
        public Task<IEnumerable<CropsDto>> GetAll();
        public Task<Crops> GetById(int id);
        public Task<Crops> Save(Crops entity);
        public Task Update(Crops entity);
    }
}
