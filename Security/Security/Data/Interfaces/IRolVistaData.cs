using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRolVistaData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<RolVistaDto>> GetAll();
        public Task<RolVista> GetById(int id);
        public Task<RolVista> Save(RolVista entity);
        public Task Update(RolVista entity);
    }
}
