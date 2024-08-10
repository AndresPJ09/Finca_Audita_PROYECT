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
    public class FarmCropsData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public FarmCropsData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.farmCrops.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FarmCropsDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Code,
                Calification_total,
                State
            FROM dbo.Crops
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<FarmCropsDto>(sql);
        }

        public async Task<FarmCrops> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Crops WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<FarmCrops>(sql, new { Id = id });
        }

        public async Task<FarmCrops> Save(FarmCrops entity)
        {
            context.farmCrops.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(FarmCrops entity)
        {
            context.farmCrops.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
