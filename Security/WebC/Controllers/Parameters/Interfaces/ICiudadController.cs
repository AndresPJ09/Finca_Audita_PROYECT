using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Parameters.Interfaces
{
    public interface ICiudadController
    {
        Task<ActionResult<IEnumerable<CiudadDto>>> GetAll();
        Task<ActionResult<CiudadDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<CiudadDto>> Save([FromBody] CiudadDto entity);
        Task<IActionResult> Update(int id, CiudadDto entity);
        Task<IActionResult> Delete(int id);
    }
}
