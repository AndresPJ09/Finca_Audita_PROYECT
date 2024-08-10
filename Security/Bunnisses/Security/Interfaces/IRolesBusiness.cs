using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interfaces
{
    public interface IRolesBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<RolDto>> GetAll();
        Task<RolDto> GetById(int id);
        Task<Rol> Save(RolDto entity);
        Task Update(int id, RolDto entity);
        Task<RolDto> GetByNombre(string nombre);
    }
}
