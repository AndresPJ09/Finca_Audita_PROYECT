using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPersonaData
    {
        public Task Delete(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<IEnumerable<PersonaDto>> GetAll();
        public Task<Persona> GetById(int id);
        public Task<Persona> Save(Persona entity);
        public Task Update(Persona entity);
        //public Task<PagedListDto<PersonaDto>> GetDataTable(QueryFilterDto filter);
        public Task<Persona> GetByFirst_name(string firstName);
    }
}
