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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.Implementations
{
    public class RolData : IRolData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public RolData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.rol.Update(entity);
            await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Nombre, ' - ', Descripcion) AS TextoMostrar 
                    FROM 
                        dbo.Rol
                    WHERE deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<RolDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Nombre,
                Descripcion,
                State
            FROM
               dbo.Rol
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<RolDto>(sql);
        }

        public async Task<Rol> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Rol WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Rol>(sql, new { Id = id });
        }


        public async Task<Rol> Save(Rol entity)
        {
            context.rol.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(Rol entity)
        {
            context.rol.Update(entity);
            await context.SaveChangesAsync();

        }


        public async Task<Rol> GetByNombre(string nombre)
        {
            return await this.context.rol.AsNoTracking().Where(item => item.Nombre == nombre).FirstOrDefaultAsync();
        }

    }
}
