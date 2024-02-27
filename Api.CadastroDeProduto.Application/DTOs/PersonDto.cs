using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.DTOs
{
    public class PersonDto
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Document { get;  set; }
        public string Phone { get;  set; }
    }
}
