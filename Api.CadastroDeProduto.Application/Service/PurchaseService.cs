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
        private readonly IUnityOfWork _unityOfWork;
        public PurchaseService(IPurchaseRepository purchaseRepository, IPersonRepository personRepository , IProductRepository productRepository, IUnityOfWork unityOfWork)
        {
            _personRepository = personRepository;
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _unityOfWork = unityOfWork;
        }
        public async Task<ResultService<PurchaseDto>> CreateAsync(PurchaseDto purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDto>("Objeto Deve ser informado!");

            var validate = new PurchaseDtoValidator().Validate(purchaseDTO);
            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDto>("Problemas na validacão!", validate);

            try {

                // Validacao feita com o Unit of work antes de salvar. Caso nao encontre nenhum produto  ou nenhuma pessoa ele faz um rollback, caso sim ele comita
                await _unityOfWork.BeginTransaction();
                var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);
                if (productId == 0)
                {
                    var product = new Product(purchaseDTO.ProductName, purchaseDTO.CodErp, purchaseDTO.Price ?? 0);
                    await _productRepository.CreateAsync(product);
                    productId = product.Id;
                } 
                    var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);
                    var purchase = new Purchase(productId, personId);
                    
                    var data = await _purchaseRepository.CreateAsync(purchase);
                    purchaseDTO.Id = data.Id;                  
                    await _unityOfWork.Commit();
                    return ResultService.Ok<PurchaseDto>(purchaseDTO);
                

            }
            catch(Exception ex)
            {
                await _unityOfWork.RollBack();
                return ResultService.Fail<PurchaseDto>($"{ex.Message}");
            }
            
          
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

        public async Task<ResultService> RemoveAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
                return ResultService.Fail("Produto não encontrado");

            await _purchaseRepository.DeleteAsync(purchase);
            return ResultService.Ok($"Produto do id:{id} foi deletado");
        }

        public async Task<ResultService<PurchaseDto>> UpdateAsync(PurchaseDto purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDto>("Objeto deve ser informado");

            var result = new PurchaseDtoValidator().Validate(purchaseDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PurchaseDto>("Problemas com a validação dos campos", result);

            var purchase = await _purchaseRepository.GetByIdAsync(purchaseDTO.Id);
            if (purchase == null)
                return ResultService.Fail<PurchaseDto>("Compra não encontrado");

            var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);
            purchase.Edit(purchase.Id, productId, personId);
            await _purchaseRepository.EditAsync(purchase);
            return ResultService.Ok(purchaseDTO);
            
        }
    }
}
