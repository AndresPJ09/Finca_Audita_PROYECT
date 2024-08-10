using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interfaces
{
    public interface IAssessmentCriteriaData
    {
        public Task Delete(int id);
        public Task<IEnumerable<AssessmentCriteriaDto>> GetAll();
        public Task<AssessmentCriteria> GetById(int id);
        public Task<AssessmentCriteria> Save(AssessmentCriteria entity);
        public Task Update(AssessmentCriteria entity);

    }
}
