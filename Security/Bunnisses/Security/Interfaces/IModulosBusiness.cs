using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interfaces
{
    public interface IModulosBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<ModuloDto>> GetAll();
        Task<ModuloDto> GetById(int id);
        Task<Modulo> Save(ModuloDto entity);
        Task Update(int id, ModuloDto entity);
    }
}
