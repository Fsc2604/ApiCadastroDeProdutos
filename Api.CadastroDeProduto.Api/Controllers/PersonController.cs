using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.CadastroDeProduto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        /// <summary> Controller de Pessoa</summary>

        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDto personDTO)
        {
            var result = await _personService.CreateAsync(personDTO);
            if(result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
