using System;

namespace eShopSolution.Application.Catalog.ProductImages
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public  int ProductId { get; set; }
        public string ImagePath { get; set; }
        public  string Caption { get; set; }
        public  DateTime DateCreate { get; set; }
        public bool IsDefault { get; set; }
        public  int SortOrder { set; get; }
        public long FileSize { get; set; }
    }
}
