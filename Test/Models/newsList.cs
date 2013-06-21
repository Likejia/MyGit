using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class NewList<T> : List<T>
    {
        private System.Data.DataTable NewsList;
        private int? page;

        //页面索引值
        public int PageIndex { get; private set; }
        //每页记录的数量
        public int PageSize { get; private set; }
        //记录总条数
        public int TotalCount { get; private set; }
        //共有的页数和
        public int TotalPages { get; private set; }

        public NewList(List<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            //进上去取整（总记录条数/一面记录的条数）
            TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
            this.AddRange(source.Skip(PageIndex * PageSize).Take(PageSize));
        }



        //是否存在前续页
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        //是否存在后续页
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}