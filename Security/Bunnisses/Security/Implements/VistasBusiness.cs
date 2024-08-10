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
using static Dapper.SqlMapper;

namespace Bunnisses.Security.Implements
{
    public class VistasBusiness : IVistasBusiness
    {
        private readonly IVistaData data;

        public VistasBusiness(IVistaData data)
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

        public async Task<IEnumerable<VistaDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<VistaDto> GetById(int id)
        {
            Vista vista = await this.data.GetById(id);
            VistaDto vistaDto = new VistaDto();

            {
                vistaDto.Id = vista.Id;
                vistaDto.Nombre = vista.Nombre;
                vistaDto.Ruta = vista.Ruta;
                vistaDto.Modulo_id = vista.Modulo_id;
                vistaDto.State = vista.State;

                return vistaDto;
            };


        }

        public async Task<Vista> Save(VistaDto entity)
        {
            Vista vista = new Vista();
            vista = this.mapearDatos(vista, entity);

            return await data.Save(vista);
        }

        public async Task Update(int Id, VistaDto entity)
        {
            Vista vista = await this.data.GetById(Id);
            if (vista == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            vista = this.mapearDatos(vista, entity);

            await this.data.Update(vista);
        }


        private Vista mapearDatos(Vista vista, VistaDto entity)
        {
            vista.Id = entity.Id;
            vista.Nombre = entity.Nombre;
            vista.Descripcion = entity.Descripcion;
            vista.Ruta = entity.Ruta;
            vista.Modulo_id = entity.Modulo_id;
            vista.State = entity.State;

            return vista;
        }

        public async Task<VistaDto> GetByNombre(string nombre)
        {
            var vista = await this.data.GetByName(nombre);
            if (vista == null)
            {
                return null;
            }

            var vistaDto = new VistaDto
            {
                Id = vista.Id,
                Nombre = vista.Nombre,
                Ruta = vista.Ruta,
                Modulo_id = vista.Modulo_id,
                State = vista.State
            };

            return vistaDto;
        }

    }
}
