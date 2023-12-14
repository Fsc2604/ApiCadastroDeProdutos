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
    }
}
