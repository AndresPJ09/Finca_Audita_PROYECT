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
    public interface ICiudadData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<CiudadDto>> GetAll();
        public Task<Ciudad> GetById(int id);
        public Task<Ciudad> Save(Ciudad entity);
        public Task Update(Ciudad entity);
    }
}
