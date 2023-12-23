using Api.CadastroDeProduto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Service.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDto>> CreateAsync(PurchaseDto purchaseDTO);
        Task<ResultService<PurchaseDetailDto>> GetByIdAsync(int Id);
        Task<ResultService<ICollection<PurchaseDetailDto>>> GetAsync();
        Task<ResultService<PurchaseDto>> UpdateAsync(PurchaseDto purchaseDTO);
        Task<ResultService> RemoveAsync(int id);
    }
}
