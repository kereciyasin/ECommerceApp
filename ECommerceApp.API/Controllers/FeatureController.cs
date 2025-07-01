using ECommerceApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {

        private static List<Feature> _features = new List<Feature>(); // Geçici olarak memory içi veri

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_features);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var feature = _features.FirstOrDefault(f => f.Id == id);
            if (feature == null)
                return NotFound();
            return Ok(feature);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Feature feature)
        {
            feature.Id = _features.Count > 0 ? _features.Max(f => f.Id) + 1 : 1;
            _features.Add(feature);
            return CreatedAtAction(nameof(GetById), new { id = feature.Id }, feature);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Feature updatedFeature)
        {
            var feature = _features.FirstOrDefault(f => f.Id == id);
            if (feature == null)
                return NotFound();

            feature.Name = updatedFeature.Name;
            feature.ProductId = updatedFeature.ProductId;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var feature = _features.FirstOrDefault(f => f.Id == id);
            if (feature == null)
                return NotFound();

            _features.Remove(feature);
            return NoContent();
        }
    }
}
