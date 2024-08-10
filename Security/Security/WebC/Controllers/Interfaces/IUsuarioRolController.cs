using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IUsuarioRolController
    {
        Task<ActionResult<IEnumerable<UsuarioRolDto>>> GetAll();
        Task<ActionResult<UsuarioRolDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<UsuarioRolDto>> Save([FromBody] UsuarioRolDto entity);
        Task<IActionResult> Update(int id, UsuarioRolDto entity);
        Task<IActionResult> Delete(int id);
    }
}
