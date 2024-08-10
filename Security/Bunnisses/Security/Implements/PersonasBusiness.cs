using Bunnisses.Security.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bunnisses.Security.Implements
{
    public class PersonasBusiness : IPersonasBusiness
    {
        private readonly IPersonaData data;

        public PersonasBusiness(IPersonaData data)
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

        public async Task<IEnumerable<PersonaDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<PersonaDto> GetById(int id)
        {
            Persona persona = await this.data.GetById(id);
            PersonaDto personaDto = new PersonaDto();

            {
                personaDto.Id = persona.Id;
                personaDto.primer_nombre = persona.primer_nombre;
                personaDto.segundo_nombre = persona.segundo_nombre;
                personaDto.correo_electronico = persona.correo_electronico ;
                personaDto.fecha_de_nacimiento = persona.fecha_de_nacimiento;
                personaDto.genero = persona.genero;
                personaDto.direccion = persona.direccion;
                personaDto.tipo_de_documento = persona.tipo_de_documento;
                personaDto.documento = persona.documento;
                personaDto.Ciudad_id = persona.Ciudad_id;
                personaDto.State = persona.State;

                return personaDto;
            };


        }

        public async Task<Persona> Save(PersonaDto entity)
        {
            Persona persona = new Persona();
            persona = this.mapearDatos(persona, entity);

            return await data.Save(persona);
        }

        public async Task Update(int Id, PersonaDto entity)
        {
            Persona persona = await this.data.GetById(Id);
            if (persona == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            persona = this.mapearDatos(persona, entity);

            await this.data.Update(persona);
        }

        private Persona mapearDatos(Persona persona, PersonaDto entity)
        {
            persona.Id = entity.Id;
            persona.primer_nombre = entity.primer_nombre;
            persona.segundo_nombre = entity.segundo_nombre;
            persona.correo_electronico = entity.correo_electronico;
            persona.fecha_de_nacimiento = entity.fecha_de_nacimiento;
            persona.genero = entity.genero;
            persona.direccion = entity.direccion;
            persona.tipo_de_documento = entity.tipo_de_documento;
            persona.documento = entity.documento;
            persona.Ciudad_id = entity.Ciudad_id;
            persona.State = entity.State;

            return persona;
        }

        public async Task<PersonaDto> GetByFirst_name(string firstName)
        {
            var persona = await this.data.GetByFirst_name(firstName);
            if (persona == null)
            {
                return null;
            }

            return new PersonaDto
            {
                Id = persona.Id,
                primer_nombre = persona.primer_nombre,
                segundo_nombre = persona.segundo_nombre,
                correo_electronico = persona.correo_electronico,
                fecha_de_nacimiento = persona.fecha_de_nacimiento,
                genero = persona.genero,
                direccion = persona.direccion,
                tipo_de_documento = persona.tipo_de_documento,
                documento = persona.documento,
                Ciudad_id = persona.Ciudad_id,
                State = persona.State
            };
        }

    }
}
