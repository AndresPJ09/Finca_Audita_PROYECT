using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interfaces
{
    public interface IRolesVistasBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<RolVistaDto>> GetAll();
        Task<RolVistaDto> GetById(int id);
        Task<RolVista> Save(RolVistaDto entity);
        Task Update(int id, RolVistaDto entity);
    }
}
