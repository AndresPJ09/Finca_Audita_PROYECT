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
    public class RolBusiness : IRolesBusiness
    {
        private readonly IRolData data;

        public RolBusiness(IRolData data)
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

        public async Task<IEnumerable<RolDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<RolDto> GetById(int id)
        {
            Rol rol = await this.data.GetById(id);
            RolDto rolDto = new RolDto();

            {
                rolDto.Id = rol.Id;
                rolDto.Nombre = rol.Nombre;
                rolDto.Descripcion = rol.Descripcion;
                rolDto.State = rol.State;

                return rolDto;
            };


        }

        public async Task<Rol> Save(RolDto entity)
        {
            Rol rol = new Rol();
            rol = this.mapearDatos(rol, entity);

            return await data.Save(rol);
        }

        public async Task Update(int Id, RolDto entity)
        {
            Rol rol = await this.data.GetById(Id);
            if (rol == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            rol = this.mapearDatos(rol, entity);

            await this.data.Update(rol);
        }

        private Rol mapearDatos(Rol rol, RolDto entity)
        {
            rol.Id = entity.Id;
            rol.Nombre = entity.Nombre;
            rol.Descripcion = entity.Descripcion;
            rol.State = entity.State;

            return rol;
        }


        public async Task<RolDto> GetByNombre(string nombre)
        {
            Rol rol = await this.data.GetByNombre(nombre);
            if (rol == null)
            {
                return null; // O lanza una excepción si prefieres
            }

            return new RolDto
            {
                Id = rol.Id,
                Nombre = rol.Nombre,
                Descripcion = rol.Descripcion,
                State = rol.State
            };
        }
    }
}