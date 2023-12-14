using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.CadastroDeProduto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary> Controller de Produto</summary>

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ProductDto productDTO)
        {
            var result = await _productService.CreateAsync(productDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _productService.GetAsync();
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductDto productDTO)
        {
            var result = await _productService.UpdateAsync(productDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _productService.RemoveAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
