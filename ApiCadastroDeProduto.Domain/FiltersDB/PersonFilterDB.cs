using Api.CadastroDeProduto.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.FiltersDB
{
    public class PersonFilterDB : PagedBaseRequest
    {
        public string? Name { get; set; }
    }
}
