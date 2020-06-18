﻿using System.Collections.Generic;
using eShopSolution.ViewModels.Catalog.Common;

namespace eShopSolution.ViewModels.Catalog.Products.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}