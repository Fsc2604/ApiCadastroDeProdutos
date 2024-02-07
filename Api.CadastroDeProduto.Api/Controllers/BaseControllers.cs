using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.CadastroDeProduto.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseControllers : ControllerBase
    {

        [NonAction]
        public bool ValidPermission(List<string> permissionUser, List<string> permissionNeeded)
        {
            return permissionNeeded.Any(x => permissionUser.Contains(x));
        }
        [NonAction]
        public IActionResult Forbidden()
        {
            var obj = new
            {
                code = "Permissão_negada",
                message = "Usuário não tem permissão para acessar esse recurso"
            };

            return new ObjectResult(obj) { StatusCode = 403 };
        }
    }
        
 }
