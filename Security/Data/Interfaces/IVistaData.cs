using Entity.Dto;
using Data.Implementations;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IVistaData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<VistaDto>> GetAll();
        public Task<Vista> GetById(int id);
        public Task<Vista> Save(Vista entity);
        public Task Update(Vista entity);
        public Task<Vista> GetByName(string nombre);
    }
}
