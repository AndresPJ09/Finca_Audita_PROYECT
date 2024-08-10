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
    public class ModulosBusiness : IModulosBusiness
    {
        private readonly IModuloData data;

        public ModulosBusiness(IModuloData data)
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

        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            return await this.data.GetAll();
        }


        public async Task<ModuloDto> GetById(int id)
        {
            Modulo modulo = await this.data.GetById(id);
            ModuloDto moduloDto = new ModuloDto();

            {
                moduloDto.Id = modulo.Id;
                moduloDto.Nombre = modulo.Nombre;
                moduloDto.Descripcion = modulo.Descripcion;
                moduloDto.Position = modulo.Position;
                moduloDto.State = modulo.State;

                return moduloDto;
            }

        }

        public async Task<Modulo> Save(ModuloDto entity)
        {
            Modulo modulo = new Modulo();
            modulo = this.mapearDatos(modulo, entity);

            return await data.Save(modulo);
        }


        public async Task Update(int Id, ModuloDto entity)
        {
            Modulo modulo = await this.data.GetById(Id);
            if (modulo == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            modulo = this.mapearDatos(modulo, entity);

            await this.data.Update(modulo);
        }


        private Modulo mapearDatos(Modulo modulo, ModuloDto entity)
        {
            modulo.Id = entity.Id;
            modulo.Nombre = entity.Nombre;
            modulo.Descripcion = entity.Descripcion;
            modulo.Position = entity.Position;
            modulo.State = entity.State;

            return modulo;
        }
    }
}
