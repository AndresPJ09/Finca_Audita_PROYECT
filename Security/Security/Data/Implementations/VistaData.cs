using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class VistaData : IVistaData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public VistaData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.vistas.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Nombre, ' - ', Descripcion , ' - ', Ruta) AS TextoMostrar 
                    FROM 
                        dbo.Vistas
                    WHERE deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }


        public async Task<IEnumerable<VistaDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Nombre,
                Descripcion,
                Ruta,
                Modulo_id,
                State
            FROM dbo.Vistas
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<VistaDto>(sql);
        }

        public async Task<Vista> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Vista WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Vista>(sql, new { Id = id });
        }

        

        public async Task<Vista> Save(Vista entity)
        {
            context.vistas.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Vista entity)
        {
            context.vistas.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Vista> GetByName(string nombre)
        {
            return await this.context.vistas.AsNoTracking().Where(item => item.Nombre == nombre).FirstOrDefaultAsync();
        }
    }
}
