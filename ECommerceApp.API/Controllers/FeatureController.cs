using ECommerceApp.Business.Services;
using ECommerceApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {

        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> GetAll()
        {
            var features = await _featureService.GetAllAsync();
            return Ok(features);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetById(int id)
        {
            var feature = await _featureService.GetByIdAsync(id);
            if (feature == null)
                return NotFound();
            return Ok(feature);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Feature feature)
        {
            await _featureService.AddAsync(feature);
            return CreatedAtAction(nameof(GetById), new { id = feature.Id }, feature);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Feature feature)
        {
            if (id != feature.Id)
                return BadRequest();

            await _featureService.UpdateAsync(feature);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _featureService.DeleteAsync(id);
            return NoContent();
        }
    }
}
