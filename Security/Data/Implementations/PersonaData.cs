using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations
{
    public class PersonaData : IPersonaData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public PersonaData(ApplicationDbContexts context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.Deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.persona.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id,
                CONCAT(primer_nombre, ' - ', segundo_nombre) AS TextoMostrar
            FROM 
                dbo.Persona
            WHERE deleted_at IS NULL AND State = 1
            ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<PersonaDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                primer_nombre,
                segundo_nombre,
                correo_electronico,
                fecha_de_nacimiento,
                genero,
                direccion,
                tipo_de_documento,
                documento,
                ciudad,
                State
            FROM dbo.Persona
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<PersonaDto>(sql);
        }
        

        public async Task<Persona> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Persona WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Persona>(sql, new { Id = id });
        }


        public async Task<Persona> Save(Persona entity)
        {
            entity.Updated_at = null;
            entity.Deleted_at = null;
            context.persona.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Persona entity)
        {
            context.persona.Update(entity);
            await context.SaveChangesAsync();
        }

       /*Task<PagedListDto<PersonaDto>> IPersonaData.GetDataTable(QueryFilterDto filter)
        {
            throw new NotImplementedException();
        }
       */

        public async Task<Persona> GetByFirst_name(string firstName)
        {
            return await this.context.persona.AsNoTracking().Where(item => item.primer_nombre == firstName).FirstOrDefaultAsync();
        }
    }
}
