using Bunnisses.Security.Interfaces;
using Data.Implementations;
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
    public class RolesVistasBusiness : IRolesVistasBusiness
    {
        private readonly IRolVistaData data;

        public RolesVistasBusiness(IRolVistaData data)
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

        public async Task<IEnumerable<RolVistaDto>> GetAll()
        {
            return await this.data.GetAll();
        }


        public async Task<RolVistaDto> GetById(int id)
        {
            RolVista rolVista = await this.data.GetById(id);
            RolVistaDto rolVistaDto = new RolVistaDto();

            {
                rolVistaDto.Id = rolVista.Id;
                rolVistaDto.Rol_id = rolVista.Rol_id;
                rolVistaDto.Vista_id = rolVista.Vista_id;
                rolVistaDto.State = rolVista.State;

                return rolVistaDto;
            }

        }

        public async Task<RolVista> Save(RolVistaDto entity)
        {
            RolVista rolVista = new RolVista();
            rolVista = this.mapearDatos(rolVista, entity);

            return await data.Save(rolVista);
        }


        public async Task Update(int Id, RolVistaDto entity)
        {
            RolVista rolVista = await this.data.GetById(Id);
            if (rolVista == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            rolVista = this.mapearDatos(rolVista, entity);

            await this.data.Update(rolVista);
        }


        private RolVista mapearDatos(RolVista rolVista, RolVistaDto entity)
        {
            rolVista.Id = entity.Id;
            rolVista.Rol_id = entity.Rol_id;
            rolVista.Vista_id = entity.Vista_id;
            rolVista.State = entity.State;

            return rolVista;
        }
    }
}
