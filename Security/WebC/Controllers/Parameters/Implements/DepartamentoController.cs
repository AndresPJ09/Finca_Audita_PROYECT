using Bunnisses.Security.Implements;
using Bunnisses.Security.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Parameters.Interfaces;

namespace WebC.Controllers.Parameters.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase, IDepartamentoController
    {
        private readonly IDepartamentoBusiness _DepartamentoBusiness;

        public DepartamentoController(IDepartamentoBusiness DepartamentoBusiness)
        {
            _DepartamentoBusiness = DepartamentoBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetAll()
        {
            var result = await _DepartamentoBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoDto>> GetById(int id)
        {
            var result = await _DepartamentoBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _DepartamentoBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<DepartamentoDto>> Save([FromBody] DepartamentoDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _DepartamentoBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartamentoDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _DepartamentoBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _DepartamentoBusiness.Delete(id);
            return NoContent();
        }
    }
}
