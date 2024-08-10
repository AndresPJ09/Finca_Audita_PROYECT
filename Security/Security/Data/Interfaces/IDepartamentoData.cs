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
    public interface IDepartamentoData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<DepartamentoDto>> GetAll();
        public Task<Departamento> GetById(int id);
        public Task<Departamento> Save(Departamento entity);
        public Task Update(Departamento entity);
    }
}
