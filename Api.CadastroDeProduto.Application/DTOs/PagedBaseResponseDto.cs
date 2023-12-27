using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.DTOs
{
    public class PagedBaseResponseDto<T>
    {
        public PagedBaseResponseDto(int totalRegisters, List<T>  data)
        {
                TotalRegisters = totalRegisters;
                data = data;
        }

        public int TotalRegisters { get; private set; }
        public List<T>  data { get; private set; }
    }
}
