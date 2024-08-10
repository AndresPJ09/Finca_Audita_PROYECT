using Bunnisses.Security.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Interfaces;

namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioRolController : ControllerBase, IUsuarioRolController
    {
        private readonly IUsuariosRolesBusiness _UsuarioRoleBusiness;

        public UsuarioRolController(IUsuariosRolesBusiness UsuariosRolesBusiness)
        {
            _UsuarioRoleBusiness = UsuariosRolesBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRolDto>>> GetAll()
        {
            var result = await _UsuarioRoleBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRolDto>> GetById(int id)
        {
            var result = await _UsuarioRoleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _UsuarioRoleBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioRolDto>> Save([FromBody] UsuarioRolDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _UsuarioRoleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioRolDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _UsuarioRoleBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _UsuarioRoleBusiness.Delete(id);
            return NoContent();
        }

    }
}
