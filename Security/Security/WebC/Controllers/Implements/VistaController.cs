using Bunnisses.Security.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Interfaces;

namespace WebC.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class VistaController : ControllerBase, IVistaController
    {
        private readonly IVistasBusiness _VistasBusiness;

        public VistaController(IVistasBusiness VistasBusiness)
        {
            _VistasBusiness = VistasBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VistaDto>>> GetAll()
        {
            var result = await _VistasBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VistaDto>> GetById(int id)
        {
            var result = await _VistasBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _VistasBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<VistaDto>> Save([FromBody] VistaDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _VistasBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VistaDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _VistasBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _VistasBusiness.Delete(id);
            return NoContent();
        }

        [HttpGet("Nombre/{nombre}")]
        public async Task<ActionResult<VistaDto>> GetByNombre(string nombre)
        {
            var result = await _VistasBusiness.GetByNombre(nombre);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
