using AutoMapper;
using ECommerceApp.Business.Services;
using ECommerceApp.Entities.Concrete;
using ECommerceApp.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {

        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeatureDto>>> GetAll()
        {
            var features = await _featureService.GetAllAsync();
            var featureDtos = _mapper.Map<IEnumerable<FeatureDto>>(features);
            return Ok(featureDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeatureDto>> GetById(int id)
        {
            var feature = await _featureService.GetByIdAsync(id);
            if (feature == null)
                return NotFound();
            var featureDto = _mapper.Map<FeatureDto>(feature);
            return Ok(featureDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FeatureDto featureDto)
        {
            var feature = _mapper.Map<Feature>(featureDto);
            await _featureService.AddAsync(feature);
            var createdDto = _mapper.Map<FeatureDto>(feature);
            return CreatedAtAction(nameof(GetById), new { id = createdDto.Id }, createdDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] FeatureDto featureDto)
        {
            if (id != featureDto.Id)
                return BadRequest();

            var feature = _mapper.Map<Feature>(featureDto);
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

