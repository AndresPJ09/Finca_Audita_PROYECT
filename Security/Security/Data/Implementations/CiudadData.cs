using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Contexts;
using Entity.Model.parameters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class CiudadData : ICiudadData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public CiudadData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.ciudad.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id,
                CONCAT(Nombre, ' - ', Descripcion) AS TextoMostrar
            FROM 
                dbo.Ciudad
            WHERE deleted_at IS NULL AND State = 1
            ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<CiudadDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Nombre,
                Descripcion,
                Depatamento_id,
                State
            FROM dbo.Ciudad
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";
            return await context.QueryAsync<CiudadDto>(sql);

        }

        public async Task<Ciudad> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Ciudad WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Ciudad>(sql, new { Id = id });
        }

        public async Task<Ciudad> Save(Ciudad entity)
        {
            entity.Updated_at = null;
            entity.Deleted_at = null;
            context.ciudad.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Ciudad entity)
        {
            context.ciudad.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
