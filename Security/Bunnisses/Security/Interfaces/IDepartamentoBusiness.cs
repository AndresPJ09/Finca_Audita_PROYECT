using Entity.Dto;
using Entity.Model.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interfaces
{
    public interface IDepartamentoBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<DepartamentoDto>> GetAll();
        Task<DepartamentoDto> GetById(int id);
        Task<Departamento> Save(DepartamentoDto entity);
        Task Update(int id, DepartamentoDto entity);
    }
}
