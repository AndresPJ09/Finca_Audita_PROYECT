using Data.Operational.Implements;
using Entity.Dto;
using Entity.Model.Operational;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interfaces
{
    public interface ICheckListData
    {
        public Task Delete(int id);
        public Task<IEnumerable<ChecklistDto>> GetAll();
        public Task<CheckLists> GetById(int id);
        public Task<CheckLists> Save(CheckLists entity);
        public Task Update(CheckLists entity);
    }
}
