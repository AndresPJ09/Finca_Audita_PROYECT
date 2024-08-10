using Entity.Dto;
using Entity.Model.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interfaces
{
    public interface ICiudadBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CiudadDto>> GetAll();
        Task<CiudadDto> GetById(int id);
        Task<Ciudad> Save(CiudadDto entity);
        Task Update(int id, CiudadDto entity);
    }
}
