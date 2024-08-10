using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IModuloController
    {
        Task<ActionResult<IEnumerable<ModuloDto>>> GetAll();
        Task<ActionResult<ModuloDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<ModuloDto>> Save([FromBody] ModuloDto entity);
        Task<IActionResult> Update(int id, ModuloDto entity);
        Task<IActionResult> Delete(int id);
    }
}
