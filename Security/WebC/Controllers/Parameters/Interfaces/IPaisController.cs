using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IPaisController
    {
        Task<ActionResult<IEnumerable<PaisDto>>> GetAll();
        Task<ActionResult<PaisDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<PaisDto>> Save([FromBody] PaisDto entity);
        Task<IActionResult> Update(int id, PaisDto entity);
        Task<IActionResult> Delete(int id);
    }
}
