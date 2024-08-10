                                                                                                   using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebC.Controllers.Interfaces
{
    public interface IUsuarioController
    {
        Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll();
        Task<ActionResult<UsuarioDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<UsuarioDto>> Save([FromBody] UsuarioDto entity);
        Task<IActionResult> Update(int id, UsuarioDto entity);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Login([FromBody] LoginDto loginRequest);
        Task<ActionResult<IEnumerable<Vista>>> GetMenuByUsuarioRol(int usuario_id);
    }
}
