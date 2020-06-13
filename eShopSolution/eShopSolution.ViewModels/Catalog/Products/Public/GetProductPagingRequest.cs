using eShopSolution.ViewModels.Catalog.Common;

namespace eShopSolution.ViewModels.Catalog.Products.Public
{
    public class GetProductPagingRequest:PagingRequestBase
    {
        public  int? CategoryId { get; set; }
    }
}
