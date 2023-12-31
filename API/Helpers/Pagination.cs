using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class Pagination<T> where T:class
    {
        public Pagination(int pageIndex,int pageSize,int count,IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        public int PageIndex{set;get;}
        public int PageSize{set;get;}
        public int Count{set;get;}
        public IReadOnlyList<T> Data{set;get;}


    }
}