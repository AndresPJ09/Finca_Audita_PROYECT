using Bunnisses.Security.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Implements
{
    public class PaisBusiness : IPaisBusiness
    {
        private readonly IPaisData data;

        public PaisBusiness(IPaisData data)
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

        public async Task<IEnumerable<PaisDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<PaisDto> GetById(int id)
        {
            Pais pais = await this.data.GetById(id);
            PaisDto paisDto = new PaisDto();

            {
                paisDto.Id = pais.Id;
                paisDto.Nombre = pais.Nombre;
                paisDto.Descripcion = pais.Descripcion;
                paisDto.State = pais.State;

                return paisDto;
            };


        }

        public async Task<Pais> Save(PaisDto entity)
        {
            Pais pais = new Pais();
            pais = this.mapearDatos(pais, entity);

            return await data.Save(pais);
        }

        public async Task Update(int Id, PaisDto entity)
        {
            Pais pais = await this.data.GetById(Id);
            if (pais == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            pais = this.mapearDatos(pais, entity);

            await this.data.Update(pais);
        }

        private Pais mapearDatos(Pais pais, PaisDto entity)
        {
            pais.Id = entity.Id;
            pais.Nombre = entity.Nombre;
            pais.Descripcion = entity.Descripcion;
            pais.State = entity.State;

            return pais;
        }
    }
}
