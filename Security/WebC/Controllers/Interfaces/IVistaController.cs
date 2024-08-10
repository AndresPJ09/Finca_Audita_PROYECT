using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IVistaController
    {
        Task<ActionResult<IEnumerable<VistaDto>>> GetAll();
        Task<ActionResult<VistaDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<VistaDto>> Save([FromBody] VistaDto entity);
        Task<IActionResult> Update(int id, VistaDto entity);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<VistaDto>> GetByNombre(string nombre);
    }
}
