using Bunnisses.Security.Implements;
using Bunnisses.Security.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Interfaces;

namespace WebC.Controllers.Parameters.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : ControllerBase, IPaisController
    {
        private readonly IPaisBusiness _PaisBusiness;

        public PaisController(IPaisBusiness PaisBusiness)
        {
            _PaisBusiness = PaisBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisDto>>> GetAll()
        {
            var result = await _PaisBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaisDto>> GetById(int id)
        {
            var result = await _PaisBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _PaisBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PaisDto>> Save([FromBody] PaisDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _PaisBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaisDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _PaisBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _PaisBusiness.Delete(id);
            return NoContent();
        }

    }
}
