using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IRolController
    {
        Task<ActionResult<IEnumerable<RolDto>>> GetAll();
        Task<ActionResult<RolDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<RolDto>> Save([FromBody] RolDto entity);
        Task<IActionResult> Update(int id, RolDto entity);
        Task<IActionResult> Delete(int id);
    }
}
