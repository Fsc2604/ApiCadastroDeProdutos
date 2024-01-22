using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.CadastroDeProduto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonImageController : ControllerBase
    {
        private readonly IPersonImageService _personImageService;

        public PersonImageController(IPersonImageService personImageService)
        {  
            this._personImageService = personImageService;  
        }

        [HttpPost]
        public async Task<IActionResult> CreateImagebase64Async(PersonImageDto personImageDto) 
        { 
          var result = await _personImageService.CreateImagebase64Async(personImageDto);
            if(result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("pathImage")]
        public async Task<IActionResult> CreateImageAsync(PersonImageDto personImageDto)
        {
          var result = await _personImageService.CreateImagebase64Async(personImageDto);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);

        }
    }
}
