using Bunnisses.Security.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebC.Controllers.Parameters.Interfaces;

namespace WebC.Controllers.Parameters.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class CiudadController : ControllerBase, ICiudadController
    {
        private readonly ICiudadBusiness _CiudadBusiness;

        public CiudadController(ICiudadBusiness CiudadBusiness)
        {
            _CiudadBusiness = CiudadBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CiudadDto>>> GetAll()
        {
            var result = await _CiudadBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CiudadDto>> GetById(int id)
        {
            var result = await _CiudadBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _CiudadBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CiudadDto>> Save([FromBody] CiudadDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _CiudadBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CiudadDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _CiudadBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _CiudadBusiness.Delete(id);
            return NoContent();
        }
    }
}
