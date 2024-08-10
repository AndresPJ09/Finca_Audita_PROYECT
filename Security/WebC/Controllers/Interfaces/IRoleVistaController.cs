using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IRoleVistaController
    {
        Task<ActionResult<IEnumerable<RolVistaDto>>> GetAll();
        Task<ActionResult<RolVistaDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<RolVistaDto>> Save([FromBody] RolVistaDto entity);
        Task<IActionResult> Update(int id, RolVistaDto entity);
        Task<IActionResult> Delete(int id);
    }
}
