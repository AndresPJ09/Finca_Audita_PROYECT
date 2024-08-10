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
    public class EvidencesData : IEvidencesData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public EvidencesData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.evidences.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EvidencesDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Core,
                Document,
                State
            FROM dbo.Crops
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<EvidencesDto>(sql);
        }

        public async Task<Evidences> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Crops WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Evidences>(sql, new { Id = id });
        }

        public async Task<Evidences> Save(Evidences entity)
        {
            context.evidences.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Evidences entity)
        {
            context.evidences.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
