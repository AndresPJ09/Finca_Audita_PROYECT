using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Interfaces
{
    public interface IPersonasBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<PersonaDto>> GetAll();
        Task<PersonaDto> GetById(int id);
        Task<Persona> Save(PersonaDto entity);
        Task Update(int id, PersonaDto entity);
        Task<PersonaDto> GetByFirst_name(string firstName);
    }
}
