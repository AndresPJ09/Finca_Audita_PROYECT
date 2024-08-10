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
    public class UsuarioRolData : IUsuarioRolData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public UsuarioRolData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.usuario_rol.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Rol_id, ' - ', Usuario_id) AS TextoMostrar 
                    FROM 
                        dbo.Usuario_Rol
                    WHERE deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<UsuarioRolDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Usuario_id,
                Rol_id,
                State
            FROM dbo.Usuario_Rol
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<UsuarioRolDto>(sql);
        }

        public async Task<UsuarioRol> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Usuario_Rol WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<UsuarioRol>(sql, new { Id = id });
        }


        public async Task<UsuarioRol> Save(UsuarioRol entity)
        {
            context.usuario_rol.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(UsuarioRol entity)
        {
            context.usuario_rol.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
