using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service.Interfaces;
using ApiCadastroDeProduto.Domain.Authentication;
using ApiCadastroDeProduto.Domain.FiltersDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.CadastroDeProduto.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseControllers
    {
        /// <summary> Controller de Pessoa</summary>

        private readonly IPersonService _personService;
        private readonly ICurrentUser _currentUser;
        private List<string> _permissionNedeed = new List<string>() {"Admin"};
        private readonly List<string> _permissionUser;
        public PersonController(IPersonService personService, ICurrentUser currentUser)
        {
            _personService = personService;
            _currentUser = currentUser;
            _permissionUser =_currentUser?.Permissions?.Split(",")?.ToList() ?? new List<string>();
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PersonDto personDTO)
        {
            _permissionNedeed.Add("CadastraPessoa");
            if(!ValidPermission(_permissionUser ,_permissionNedeed))
            return Forbidden();

            var result = await _personService.CreateAsync(personDTO);
            if(result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            _permissionNedeed.Add("BuscaPessoa");
            if (!ValidPermission(_permissionUser, _permissionNedeed))
                return Forbidden();

            var result = await _personService.GetAsync();
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            _permissionNedeed.Add("BuscaPessoa");
            if (!ValidPermission(_permissionUser, _permissionNedeed))
                return Forbidden();

            var result = await _personService.GetByIdAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersonDto personDTO)
        {
            _permissionNedeed.Add("EditaPessoa");
            if (!ValidPermission(_permissionUser, _permissionNedeed))
                return Forbidden();

            var result = await _personService.UpdateAsync(personDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            _permissionNedeed.Add("DeletaPessoa");
            if (!ValidPermission(_permissionUser, _permissionNedeed))
                return Forbidden();

            var result = await _personService.DeleteAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        //Controller de Paginação

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] PersonFilterDB personFilterDb)
        {
            var result = await _personService.GetPagedAsync(personFilterDb);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

