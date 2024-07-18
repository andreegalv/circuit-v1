using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBComputadora.Model.Utils.Html
{
    public class PageSize
    {
        public PageSize(int size)
        {
            if (size != 10 && size != 20 && size != 30 && size != 0)
                throw new ArgumentOutOfRangeException();

            Size = size;
        }
        public int Size { get; set; }
        public int[] SizeCollection => new int[] { 10, 20, 30, 0 };
    }
}