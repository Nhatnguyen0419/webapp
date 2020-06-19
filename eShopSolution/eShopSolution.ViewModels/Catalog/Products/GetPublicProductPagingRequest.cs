using eShopSolution.ViewModels.Catalog.Common;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest:PagingRequestBase
    {
        public  int? CategoryId { get; set; }
    }
}
