using System.Dynamic;
using Microsoft.AspNetCore.Http;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {

        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { get; set; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public string LanguageId { set; get; }

        public IFormFile ThumbnailImage { set; get; }


    }
}
