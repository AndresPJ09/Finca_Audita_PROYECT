using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUsuarioRolData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<UsuarioRolDto>> GetAll();
        public Task<UsuarioRol> GetById(int id);
        public Task<UsuarioRol> Save(UsuarioRol entity);
        public Task Update(UsuarioRol entity);
    }
}
