using Api.CadastroDeProduto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Service.Interfaces
{
    public interface IProductService
    {
       
       
            //Criar uma produto
            Task<ResultService<ProductDto>> CreateAsync(ProductDto productDTO);

           
     
    }
}
