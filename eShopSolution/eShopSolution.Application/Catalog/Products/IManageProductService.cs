using System.Collections.Generic;
using System.Threading.Tasks;
using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;

namespace eShopSolution.Application.Catalog.Products
{
    // SOLID : Dependence
    // Instance : HS a = new HS();

    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int ProductId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
      
        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

    }
}
