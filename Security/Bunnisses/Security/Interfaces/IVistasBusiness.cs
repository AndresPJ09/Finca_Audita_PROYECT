using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interfaces
{
    public interface IVistasBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<VistaDto>> GetAll();
        Task<VistaDto> GetById(int id);
        Task<Vista> Save(VistaDto entity);
        Task Update(int id, VistaDto entity);
        Task<VistaDto> GetByNombre(string nombre);
    }
}
