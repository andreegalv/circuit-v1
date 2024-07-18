using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBComputadora.Model.Utils.Html
{
    public interface IPageSize
    {
        int Current { get; set; }
        int[] SizeCollection { get; }
    }
}
