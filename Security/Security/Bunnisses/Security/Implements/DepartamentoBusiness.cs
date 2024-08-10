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
    public class DepartamentoBusiness : IDepartamentoBusiness
    {
        private readonly IDepartamentoData data;

        public DepartamentoBusiness(IDepartamentoData data)
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

        public async Task<IEnumerable<DepartamentoDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<DepartamentoDto> GetById(int id)
        {
            Departamento departamento = await this.data.GetById(id);
            DepartamentoDto departamentoDto = new DepartamentoDto();

            {
                departamentoDto.Id = departamento.Id;
                departamentoDto.Nombre = departamento.Nombre;
                departamentoDto.Descripcion = departamento.Descripcion;
                departamentoDto.State = departamento.State;

                return departamentoDto;
            };


        }

        public async Task<Departamento> Save(DepartamentoDto entity)
        {
            Departamento departamento = new Departamento();
            departamento = this.mapearDatos(departamento, entity);

            return await data.Save(departamento);
        }

        public async Task Update(int Id, DepartamentoDto entity)
        {
            Departamento departamento = await this.data.GetById(Id);
            if (departamento == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            departamento = this.mapearDatos(departamento, entity);

            await this.data.Update(departamento);
        }

        private Departamento mapearDatos(Departamento departamento, DepartamentoDto entity)
        {
            departamento.Id = entity.Id;
            departamento.Nombre = entity.Nombre;
            departamento.Descripcion = entity.Descripcion;
            departamento.Pais_id = entity.Pais_id;
            departamento.State = entity.State;

            return departamento;
        }
    }
}
