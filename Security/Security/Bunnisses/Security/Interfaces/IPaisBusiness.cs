using Entity.Dto;
using Entity.Model.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interfaces
{
    public interface IPaisBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<PaisDto>> GetAll();
        Task<PaisDto> GetById(int id);
        Task<Pais> Save(PaisDto entity);
        Task Update(int id, PaisDto entity);
    }
}
