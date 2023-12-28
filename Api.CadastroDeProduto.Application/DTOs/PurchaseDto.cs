using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.DTOs
{
    public class PurchaseDto
    {
        public string CodErp { get; set; }
        public string Document{ get; set; }
        public int Id { get; set; }
        public string? ProductName { get; set; };
        public decimal? Price { get; set; }
    }
}
