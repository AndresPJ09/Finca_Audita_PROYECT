using Bunnisses.Security.Interfaces;
using Data.Implementations;
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



        public async Task<MenuDto> LoginAsync(LoginDto loginDto)
        {
            var usuario = await data.Login(loginDto);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var roles = await data.GetUsuarioRolesAsync(usuario.Id);

            var rolVista = new List<VistaDto>();
            foreach (var rol in roles)
            {
                var vistas = await data.GetRolesVistasAsync(rol.Id);
                rolVista.AddRange(vistas);
            }

            return new MenuDto
            {
                Usuario = new UsuarioDto
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    State = usuario.State,
                    Contraseña = usuario.Contraseña,
                    Persona_id = usuario.Persona_id
                },
                Roles = roles.ToList(),
                Vistas = rolVista.Distinct().ToList()
            };
        }

    }
}
