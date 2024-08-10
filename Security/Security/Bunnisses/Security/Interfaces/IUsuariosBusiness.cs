using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interfaces
{
    public interface IUsuariosBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UsuarioDto>> GetAll();
        Task<UsuarioDto> GetById(int id);
        Task<Usuario> Save(UsuarioDto entity);
        Task Update(int id, UsuarioDto entity);
        Task<UsuarioDto> Login(LoginDto loginDto);
        Task<IEnumerable<VistaDto>> GetMenuByUsuarioRol(int usuario_id);

    }
}
