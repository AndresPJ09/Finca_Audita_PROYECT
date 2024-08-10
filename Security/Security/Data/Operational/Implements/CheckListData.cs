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
    public class CheckListData :ICheckListData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public CheckListData(ApplicationDbContexts context, IConfiguration configuration)
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
            context.checkLists.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChecklistDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Code,
                Calification_total,
                State
            FROM dbo.AssessmentCriteria
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<ChecklistDto>(sql);
        }

        public async Task<CheckLists> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.AssessmentCriteria WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<CheckLists>(sql, new { Id = id });
        }

        public async Task<CheckLists> Save(CheckLists entity)
        {
            context.checkLists.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(CheckLists entity)
        {
            context.checkLists.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
