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
            var usuario = await this.context.usuario.FirstOrDefaultAsync(u => u.Nombre == loginDto.Nombre && u.Contraseña == loginDto.Contraseña);

            if (usuario == null)
            {
                return null;
            }
            var usuarioDto = new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                State = usuario.State,
                Contraseña = usuario.Contraseña,
                Persona_id = usuario.Persona_id
            };
            return usuarioDto;


        }

        public async Task<IEnumerable<RolDto>> GetUsuarioRolesAsync(int usuario_id)
        {
            return await context.usuario_rol
                                .Where(ur => ur.Usuario_Id == usuario_id)
                                .Select(ur => new RolDto { Id = ur.Rol.Id, Nombre = ur.Rol.Nombre})
                                .ToListAsync();
        }

        public async Task<IEnumerable<VistaDto>> GetRolesVistasAsync(int rol_id)
        {
            return await context.rol_vista
                               .Where(rv => rv.Rol_id == rol_id)
                               .Select(rv => new VistaDto { Id = rv.Vista.Id, Nombre = rv.Vista.Nombre, Descripcion = rv.Vista.Descripcion })
                               .ToListAsync();
        }
    }
}
