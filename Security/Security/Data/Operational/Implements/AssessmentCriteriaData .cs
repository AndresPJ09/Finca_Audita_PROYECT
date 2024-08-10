using Data.Operational.Interfaces;
using Entity.Dto;
using Entity.Model.Contexts;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Implements
{
    public class AssessmentCriteriaData : IAssessmentCriteriaData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public AssessmentCriteriaData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.assessment_criteria.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AssessmentCriteriaDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Name,
                Rating_range,
                Type_criterian,
                State
            FROM dbo.AssessmentCriteria
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<AssessmentCriteriaDto>(sql);
        }

        public async Task<AssessmentCriteria> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.AssessmentCriteria WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<AssessmentCriteria>(sql, new { Id = id });
        }

        public async Task<AssessmentCriteria> Save(AssessmentCriteria entity)
        {
            context.assessment_criteria.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(AssessmentCriteria entity)
        {
            context.assessment_criteria.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
