using Data.Operational.Interfaces;
using Entity.Dto;
using Entity.Model.Contexts;
using Entity.Model.Operational;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Implements
{
    public class CropsData : ICropsData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public CropsData(ApplicationDbContexts context, IConfiguration configuration)
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
            entity.Deleted_At = DateTime.Parse(DateTime.Today.ToString());
            context.crops.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CropsDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Code,
                Calification_total,
                State
            FROM dbo.Crops
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<CropsDto>(sql);
        }

        public async Task<Crops> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Crops WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Crops>(sql, new { Id = id });
        }

        public async Task<Crops> Save(Crops entity)
        {
            context.crops.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Crops entity)
        {
            context.crops.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
