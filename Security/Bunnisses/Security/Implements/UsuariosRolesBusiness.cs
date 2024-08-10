using Bunnisses.Security.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Implements
{
    public class UsuariosRolesBusiness : IUsuariosRolesBusiness
    {
        private readonly IUsuarioRolData data;

        public UsuariosRolesBusiness(IUsuarioRolData data)
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

        public async Task<IEnumerable<UsuarioRolDto>> GetAll()
        {
            return await this.data.GetAll();
        }


        public async Task<UsuarioRolDto> GetById(int id)
        {
            UsuarioRol usuarioRol = await this.data.GetById(id);
            UsuarioRolDto usuarioRolDto = new UsuarioRolDto();

            {
                usuarioRolDto.Id = usuarioRol.Id;
                usuarioRolDto.Usuario_Id = usuarioRol.Usuario_Id;
                usuarioRolDto.Rol_id = usuarioRol.Rol_id;
                usuarioRolDto.State = usuarioRol.State;

                return usuarioRolDto;
            }

        }

        public async Task<UsuarioRol> Save(UsuarioRolDto entity)
        {
            UsuarioRol usuarioRol = new UsuarioRol();
            usuarioRol = this.mapearDatos(usuarioRol, entity);

            return await data.Save(usuarioRol);
        }


        public async Task Update(int Id, UsuarioRolDto entity)
        {
            UsuarioRol usuarioRol = await this.data.GetById(Id);
            if (usuarioRol == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            usuarioRol = this.mapearDatos(usuarioRol, entity);

            await this.data.Update(usuarioRol);
        }


        private UsuarioRol mapearDatos(UsuarioRol usuarioRol, UsuarioRolDto entity)
        {
            usuarioRol.Id = entity.Id;
            usuarioRol.Usuario_Id = entity.Usuario_Id;
            usuarioRol.Rol_id = entity.Rol_id;
            usuarioRol.State = entity.State;

            return usuarioRol;
        }


    }
}
