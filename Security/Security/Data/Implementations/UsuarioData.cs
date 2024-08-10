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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Data.Implementations
{
    public class UsuarioData : IUsuarioData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public UsuarioData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.usuario.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Nombre, ' - ', Contraseña) AS TextoMostrar 
                    FROM 
                        dbo.Usuario
                    WHERE deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }


        public async Task<IEnumerable<UsuarioDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Nombre,
                Contraseña,
                Persona_id,
                State
            FROM dbo.Usuario
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<UsuarioDto>(sql);
        }

        public async Task<Usuario> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Usuario WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }


        public async Task<Usuario> Save(Usuario entity)
        {
            context.usuario.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Usuario entity)
        {
            context.usuario.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<UsuarioDto> Login(LoginDto loginDto)
        {
            var sql = @"
        SELECT 
            u.Id, 
            u.Nombre, 
            u.Contraseña, 
            u.Persona_id, 
            ur.Rol_id,
            u.State 
        FROM dbo.usuario u
        INNER JOIN dbo.usuario_rol ur ON u.Id = ur.Usuario_id
        WHERE u.Nombre = @Nombre 
        AND u.Contraseña = @Contraseña 
        AND u.Deleted_at IS NULL";

            var usuario = await this.context.QueryFirstOrDefaultAsync<UsuarioDto>(sql, new
            {
                Nombre = loginDto.Nombre,
                Contraseña = loginDto.Contraseña
            });

            if (usuario == null)
            {
                throw new UnauthorizedAccessException("Usuario no encontrado o contraseña incorrecta.");
            }

            return usuario;
        }

        public async Task<IEnumerable<Vista>> GetMenuByUsuarioRol(int usuario_id)
        {
            var sql = @"SELECT 
            v.Id,
            v.Nombre,
            v.Descripcion,
            v.Ruta,
            v.Modulo_id,
            v.State,
            v.Created_at,
            v.Updated_at,
            v.Deleted_at
        FROM dbo.Vistas v
        INNER JOIN dbo.rol_vista rv ON v.Id = rv.Vista_id
        INNER JOIN dbo.Usuario_rol ur ON rv.Rol_id = ur.Rol_id
        INNER JOIN dbo.Modulo m ON v.Modulo_id = m.Id
        WHERE ur.Usuario_id = @Usuario_id 
        AND v.Deleted_at IS NULL 
        ORDER BY m.Position, v.Nombre ASC";
            return await this.context.QueryAsync<Vista>(sql, new { Usuario_id = usuario_id });
        }


    }
}
