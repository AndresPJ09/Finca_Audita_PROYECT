using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUsuarioData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<UsuarioDto>> GetAll();
        public Task<Usuario> GetById(int id);
        public Task<Usuario> Save(Usuario entity);
        public Task Update(Usuario entity);
        public Task<UsuarioDto> Login(LoginDto loginDto);
        public Task<IEnumerable<RolDto>> GetUsuarioRolesAsync(int usuario_id);
        public Task<IEnumerable<VistaDto>> GetRolesVistasAsync(int rol_id);
    }
}
