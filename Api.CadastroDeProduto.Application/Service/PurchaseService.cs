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
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public PurchaseService(IPurchaseRepository purchaseRepository, IPersonRepository personRepository , IProductRepository productRepository)
        {
            _personRepository = personRepository;
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
        }
        public async Task<ResultService<PurchaseDto>> CreateAsync(PurchaseDto purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDto>("Objeto Deve ser informado!");

            var validate = new PurchaseDtoValidator().Validate(purchaseDTO);
            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDto>("Problemas na validacão!", validate);

            var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);
            var purchase = new Purchase(productId, personId);


            var data = await _purchaseRepository.CreateAsync(purchase);
           purchaseDTO.Id = data.Id;
            return ResultService.Ok<PurchaseDto>(purchaseDTO);
        }

        public async Task<ResultService<ICollection<PurchaseDetailDto>>> GetAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PurchaseDetailDto>>(purchases));
        }

        public async Task<ResultService<PurchaseDetailDto>> GetByIdAsync(int Id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(Id);
            if (purchase == null)
                return ResultService.Fail<PurchaseDetailDto>("Compra não encontrada");

                return ResultService.Ok(_mapper.Map<PurchaseDetailDto>(purchase));
        }

  
    }
}
