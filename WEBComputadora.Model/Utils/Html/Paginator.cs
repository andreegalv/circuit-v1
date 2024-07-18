using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBComputadora.Model.Utils.Html
{
    public class Paginator : IPaginator
    {
        public Paginator(int totalRecords, IPageSize pageSize)
        {
            if (totalRecords < 0)
                throw new ArgumentOutOfRangeException();

            if (pageSize == null || (pageSize != null && pageSize.Current < 0))
                throw new ArgumentOutOfRangeException();

            if (pageSize.Current > totalRecords && totalRecords > 0)
                throw new ArgumentException();

            TotalRecords = totalRecords;
            PageSize = pageSize.Current;

            Initialize();
        }
        public Paginator(int totalRecords, int pageSize)
        {
            if (totalRecords < 0)
                throw new ArgumentOutOfRangeException();

            if (pageSize < 0)
                throw new ArgumentOutOfRangeException();

            if (pageSize > totalRecords && totalRecords > 0)
                throw new ArgumentException();

            TotalRecords = totalRecords;
            PageSize = pageSize;

            Initialize();
        }

        public int TotalRecords { get; private set; }
        public int CurrentPage { get; private set; }
        public int FirstPage { get; private set; }
        public int LastPage { get; private set; }
        public bool HasPagination => (PageSize > 0) ? true : false;
        public int PageSize { get; private set; }
        public int Skip { get; private set; }
        public int Take => (PageSize > 0) ? PageSize : TotalRecords;

        public void SetCurrentPage(int currentPage)
        {
            if (currentPage <= 0 || currentPage > LastPage)
                throw new ArgumentException();

            CurrentPage = currentPage;
            Skip = 0;

            if (CurrentPage > 1)
            {
                Skip = (CurrentPage - 1) * PageSize;
            }
        }

        private void Initialize()
        {
            FirstPage = 1;
            CurrentPage = 1;
            Skip = 0;

            if (PageSize > 0)
            {
                LastPage = TotalRecords / PageSize;

                if (TotalRecords < PageSize)
                    LastPage = 1;
                else if (TotalRecords % PageSize > 0)
                    LastPage += 1;
            }
            else
            {
                CurrentPage = 1;
                LastPage = 1;
            }
        }
    }
}