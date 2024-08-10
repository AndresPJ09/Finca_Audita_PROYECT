using Bunnisses.Security.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Interfaces;

namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class RolVistaController : ControllerBase, IRoleVistaController
    {
        private readonly IRolesVistasBusiness _RolesVistasBusiness;

        public RolVistaController(IRolesVistasBusiness RolesVistasBusiness)
        {
            _RolesVistasBusiness = RolesVistasBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolVistaDto>>> GetAll()
        {
            var result = await _RolesVistasBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolVistaDto>> GetById(int id)
        {
            var result = await _RolesVistasBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _RolesVistasBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RolVistaDto>> Save([FromBody] RolVistaDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _RolesVistasBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolVistaDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _RolesVistasBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _RolesVistasBusiness.Delete(id);
            return NoContent();
        }
    }
}
