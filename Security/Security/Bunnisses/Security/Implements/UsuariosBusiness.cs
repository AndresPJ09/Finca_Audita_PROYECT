using Bunnisses.Security.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Bunnisses.Security.Implements
{
    public class UsuariosBusiness : IUsuariosBusiness
    {
        private readonly IUsuarioData data;

        public UsuariosBusiness(IUsuarioData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<IEnumerable<UsuarioDto>> GetAll()
        {
            return await this.data.GetAll();
        }


        public async Task<UsuarioDto> GetById(int id)
        {
            Usuario usuario = await this.data.GetById(id);
            UsuarioDto usuarioDto = new UsuarioDto();

            {
                usuarioDto.Id = usuario.Id;
                usuarioDto.Nombre = usuario.Nombre;
                usuarioDto.Contraseña= usuario.Contraseña;
                usuarioDto.Persona_id = usuario.Persona_id;
                usuarioDto.State = usuario.State;

            return usuarioDto;
            }

        }

        public async Task<Usuario> Save(UsuarioDto entity)
        {
            Usuario usuario = new Usuario();
            usuario = this.mapearDatos(usuario, entity);

            return await data.Save(usuario);
        }


        public async Task Update(int Id, UsuarioDto entity)
        {
            Usuario usuario = await this.data.GetById(Id);
            if (usuario == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            usuario = this.mapearDatos(usuario, entity);

            await this.data.Update(usuario);
        }


        private Usuario mapearDatos(Usuario usuario, UsuarioDto entity)
        {
            usuario.Id = entity.Id;
            usuario.Nombre = entity.Nombre;
            usuario.Contraseña = entity.Contraseña;
            usuario.Persona_id = entity.Persona_id;
            usuario.State = entity.State;

            return usuario;
        }



        public async Task<UsuarioDto> Login(LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Nombre) || string.IsNullOrEmpty(loginDto.Contraseña))
            {
                throw new ArgumentException("El nombre de usuario y la contraseña son obligatorios.");
            }

            var usuario = await data.Login(loginDto);
            if (usuario == null)
            {
                throw new UnauthorizedAccessException("Usuario no encontrado o contraseña incorrecta.");
            }

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Contraseña = usuario.Contraseña,
                Persona_id = usuario.Persona_id,
                Rol_id = usuario.Rol_id,
                State = usuario.State
            };
        }


        public async Task<IEnumerable<VistaDto>> GetMenuByUsuarioRol(int usuario_id)
        {
            var vistas = await this.data.GetMenuByUsuarioRol(usuario_id);

            // Map Vista to VistaDto
            var vistasDto = vistas.Select(v => new VistaDto
            {
                Id = v.Id,
                Nombre = v.Nombre,
                Descripcion = v.Descripcion,
                Ruta = v.Ruta,
                Modulo_id = v.Modulo_id,
                State = v.State
            }).ToList();

            return vistasDto;
        }



    }
}
