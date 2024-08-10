using Bunnisses.Security.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Interfaces;

namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]  

    public class PersonaController : ControllerBase, IPersonaController
    {
        private readonly IPersonasBusiness _PersonasBusiness;

        public PersonaController(IPersonasBusiness PersonasBusiness)
        {
            _PersonasBusiness = PersonasBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetAll()
        {
            var result = await _PersonasBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDto>> GetById(int id)
        {
            var result = await _PersonasBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _PersonasBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PersonaDto>> Save([FromBody] PersonaDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _PersonasBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonaDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _PersonasBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _PersonasBusiness.Delete(id);
            return NoContent();
        }

        [HttpGet("primer_nombre/{firstName}")]
        public async Task<ActionResult<PersonaDto>> GetByFirst_name(string firstName)
        {
            var result = await _PersonasBusiness.GetByFirst_name(firstName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
