using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interfaces
{
    public interface IFarmCropsData
    {
        public Task Delete(int id);
        public Task<IEnumerable<EvidencesDto>> GetAll();
        public Task<Evidences> GetById(int id);
        public Task<Evidences> Save(Evidences entity);
        public Task Update(Evidences entity);
    }
}
