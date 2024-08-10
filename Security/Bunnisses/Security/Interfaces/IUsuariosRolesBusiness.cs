using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interfaces
{
    public interface IUsuariosRolesBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UsuarioRolDto>> GetAll();
        Task<UsuarioRolDto> GetById(int id);
        Task<UsuarioRol> Save(UsuarioRolDto entity);
        Task Update(int id, UsuarioRolDto entity);
    }
}
