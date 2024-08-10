using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Parameters.Interfaces
{
    public interface IDepartamentoController
    {
        Task<ActionResult<IEnumerable<DepartamentoDto>>> GetAll();
        Task<ActionResult<DepartamentoDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<DepartamentoDto>> Save([FromBody] DepartamentoDto entity);
        Task<IActionResult> Update(int id, DepartamentoDto entity);
        Task<IActionResult> Delete(int id);
    }
}
