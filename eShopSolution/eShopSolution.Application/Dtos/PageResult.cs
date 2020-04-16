using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class PageResult<T>
    {

        //commit
        public List<T> Items { set; get; }
        public int TotalRecord { set; get; }
    }
}
