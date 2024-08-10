using Bunnisses.Security.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Bunnisses.Security.Implements
{
    public class CiudadBusiness : ICiudadBusiness
    {
        private readonly ICiudadData data;

        public CiudadBusiness(ICiudadData data)
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

        public async Task<IEnumerable<CiudadDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<CiudadDto> GetById(int id)
        {
            Ciudad ciudad = await this.data.GetById(id);
            CiudadDto ciudadDto = new CiudadDto();

            {
                ciudadDto.Id = ciudad.Id;
                ciudadDto.Nombre = ciudad.Nombre;
                ciudadDto.Descripcion = ciudad.Descripcion;
                ciudad.Departamento_id = ciudad.Departamento_id;
                ciudadDto.State = ciudad.State;

                return ciudadDto;
            };


        }

        public async Task<Ciudad> Save(CiudadDto entity)
        {
            Ciudad ciudad = new Ciudad();
            ciudad = this.mapearDatos(ciudad, entity);

            return await data.Save(ciudad);
        }

        public async Task Update(int Id, CiudadDto entity)
        {
            Ciudad ciudad = await this.data.GetById(Id);
            if (ciudad == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            ciudad = this.mapearDatos(ciudad, entity);

            await this.data.Update(ciudad);
        }

        private Ciudad mapearDatos(Ciudad ciudad, CiudadDto entity)
        {
            ciudad.Id = entity.Id;
            ciudad.Nombre = entity.Nombre;
            ciudad.Descripcion = entity.Descripcion;
            ciudad.Departamento_id = entity.Departamento_id;
            ciudad.State = entity.State;

            return ciudad;
        }
    }
}
