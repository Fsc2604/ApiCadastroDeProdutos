using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service.Interfaces;
using Api.CadastroDeProduto.Application.Validations;
using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Service
{
    public class ProductService : IProductService
    {
      private readonly IProductRepository _productRepository;
      private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<ProductDto>> CreateAsync(ProductDto productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail<ProductDto>("Objeto Deve ser informado!");

            var result = new ProductDtoValidator().Validate(productDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ProductDto>("Problemas na validacão!", result);

            var product = _mapper.Map<Product>(productDTO);
            var data = await _productRepository.CreateAsync(product);
            return ResultService.Ok<ProductDto>(_mapper.Map<ProductDto>(data));
        }
    }
}
