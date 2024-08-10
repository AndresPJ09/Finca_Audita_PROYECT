using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace WebC.Controllers.Interfaces
{
    public interface IPersonaController
    {
        Task<ActionResult<IEnumerable<PersonaDto>>> GetAll();
        Task<ActionResult<PersonaDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<PersonaDto>> Save([FromBody] PersonaDto entity);
        Task<IActionResult> Update(int id, PersonaDto entity);
        Task<IActionResult> Delete(int id);
        Task<ActionResult<PersonaDto>> GetByFirst_name(string firstName);
    }
}
