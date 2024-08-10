using Data.Implementations;
using Entity.Dto;
using Entity.Model.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPaisData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<PaisDto>> GetAll();
        public Task<Pais> GetById(int id);
        public Task<Pais> Save(Pais entity);
        public Task Update(Pais entity);
    }
}
