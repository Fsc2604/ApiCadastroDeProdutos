using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service;
using Api.CadastroDeProduto.Application.Service.Interfaces;
using ApiCadastroDeProduto.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Api.CadastroDeProduto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        /// <summary> Controller de Compra</summary>

        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PurchaseDto purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.CreateAsync(purchaseDTO);
                if (result.IsSucess)
                return Ok(result);

                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }

        }
    }
}
