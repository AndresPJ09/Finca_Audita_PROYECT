using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class RolVistaData : IRolVistaData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public RolVistaData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.rol_vista.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Rol_id, ' - ', Vista_id) AS TextoMostrar 
                    FROM 
                        dbo.Rol_Vista
                    WHERE deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<RolVistaDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Rol_id,
                Vista_id,
                State
            FROM dbo.Rol_Vista
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<RolVistaDto>(sql);
        }

        public async Task<RolVista> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Rol_Vista WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<RolVista>(sql, new { Id = id });
        }


        public async Task<RolVista> Save(RolVista entity)
        {
            context.rol_vista.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(RolVista entity)
        {
            context.rol_vista.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
