using System.Collections.Generic;

namespace eShopSolution.ViewModels.Catalog.Common
{
    public class PageResult<T>
    {

        //commit
        public List<T> Items { set; get; }
        public int TotalRecord { set; get; }
    }
}
