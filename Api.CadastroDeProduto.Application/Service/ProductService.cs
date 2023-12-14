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

        /// <summary> Criando Produto no repositório e convertendo pra dto</summary>
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

        /// <summary> Buscando Lista de Produtos no repositório e convertendo pra dto</summary>
        public async Task<ResultService<ICollection<ProductDto>>> GetAsync()
        {
            var products = await _productRepository.GetProductAsync();
            return ResultService.Ok<ICollection<ProductDto>>(_mapper.Map<ICollection<ProductDto>>(products));
        }

        /// <summary> Buscando Produto  no repositório e convertendo pra dto</summary>
        public async Task<ResultService<ProductDto>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail<ProductDto>("Produto  não encontrada!");

            return ResultService.Ok(_mapper.Map<ProductDto>(product));
        }
    
        /// <summary> Edita uma Produto</summary>
        public async Task<ResultService> UpdateAsync(ProductDto productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail("Objeto deve ser informado");

            var validation = new ProductDtoValidator().Validate(productDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com a validação dos campos", validation);

            var product = await _productRepository.GetByIdAsync(productDTO.Id);
            if (product == null)
                return ResultService.Fail("Produto não encontrado");

            product = _mapper.Map<ProductDto, Product>(productDTO, product);
            await _productRepository.EditAsync(product);
            return ResultService.Ok("Produto Editado");

        }

        /// <summary> Deleta um Produto</summary>
        public async Task<ResultService> RemoveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail("Produto não encontrado");

            await _productRepository.DeleteAsync(product);
            return ResultService.Ok($"Produto do id:{id} foi deletado");
        }

    }
}
