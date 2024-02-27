using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string CodErp { get;  set; }
        public decimal Price { get;  set; }
    }
}
