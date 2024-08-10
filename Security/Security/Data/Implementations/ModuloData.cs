using Entity.Dto;
using Data.Interfaces;
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
    public class ModuloData : IModuloData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public ModuloData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.modulo.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                     CONCAT(Nombre, ' - ', Descripcion) AS TextoMostrar
                    FROM 
                        dbo.Modulo
                    WHERE deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            var sql = @"SELECT
                    Id,
                    Nombre,
                    Descripcion,
                    Position,
                    State
                  FROM 
                      dbo.Modulo
                  WHERE deleted_at IS NULL
                  ORDER BY Id ASC";

            return await context.QueryAsync<ModuloDto>(sql);
        }


        public async Task<Modulo> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Modulo WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Modulo>(sql, new { Id = id });
        }


        public async Task<Modulo> Save(Modulo entity)
        {
            context.modulo.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Modulo entity)
        {
            context.modulo.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
