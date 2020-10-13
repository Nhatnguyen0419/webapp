using System.Collections.Generic;

namespace eShopSolution.ViewModels.Common
{
    public class PagedResult<T>
    {

        //commit
        public List<T> Items { set; get; }
        public int TotalRecord { set; get; }
    }
}
