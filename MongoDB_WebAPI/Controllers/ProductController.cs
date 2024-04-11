using BusinessLayer.Services.Abstracts;
using BusinessLayer.Services.Concretes;
using Core.Dtos.Product;
using Core.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
            => Ok(await _productService.GetAllAsync());

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
            => Ok(await _productService.GetByIdAsync(id));

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] ProductCreateDto dto)
        {
            await _productService.AddAsync(dto);
            return Ok();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] ProductUpdateDto dto)
        => Ok(await _productService.UpdateOneByIdAsync(id, dto));

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteById([FromRoute]string id)
            => Ok(await _productService.DeleteOneByIdAsync(id));

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] ProductDeleteDto dto)
          => Ok(await _productService.DeleteOneByIdAsync(dto));
    }
}
