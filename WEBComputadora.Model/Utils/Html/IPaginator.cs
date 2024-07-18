using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBComputadora.Model.Utils.Html
{
    public interface IPaginator
    {
        int TotalRecords { get; }
        int CurrentPage { get; }
        int FirstPage { get; }
        int LastPage { get; }
        bool HasPagination { get; }
        int PageSize { get; }
        int Skip { get; }
        int Take { get; }

        void SetCurrentPage(int currentPage);
    }
}
