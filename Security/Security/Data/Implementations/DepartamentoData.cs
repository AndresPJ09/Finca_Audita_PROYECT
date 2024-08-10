using Entity.Dto;
using Data.Interfaces;
using Entity.Model.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.parameters;

namespace Data.Implementations
{
    public class DepartamentoData : IDepartamentoData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public DepartamentoData(ApplicationDbContexts context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.Deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.departamento.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id,
                CONCAT(Nombre, ' - ', Descripcion) AS TextoMostrar
            FROM 
                dbo.Departamento
            WHERE deleted_at IS NULL AND State = 1
            ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<DepartamentoDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Nombre,
                Descripcion,
                Pais_id,
                State
            FROM dbo.Departamento
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";
            return await context.QueryAsync<DepartamentoDto>(sql);

        }

        public async Task<Departamento> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Departamento WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Departamento>(sql, new { Id = id });
        }

        public async Task<Departamento> Save(Departamento entity)
        {
            entity.Updated_at = null;
            entity.Deleted_at = null;
            context.departamento.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Departamento entity)
        {
            context.departamento.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
