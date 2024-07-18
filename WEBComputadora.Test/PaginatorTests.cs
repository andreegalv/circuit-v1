using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEBComputadora.Model.Utils.Html;

namespace WEBComputadora.Test
{
    [TestClass]
    public class PaginatorTests
    {
        [TestMethod]
        public void Paginator_PageSizeHigherThanTotal_ThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Paginator(30, 60));
        }
        [TestMethod]
        public void Paginator_Page_GetFirstPage()
        {
            IPaginator paginator = new Paginator(60, 10);

            Assert.AreEqual(1, paginator.CurrentPage);
        }
        [TestMethod]
        public void Paginator_TotalPageSize_ThrowsExceptionNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Paginator(60, -20));
        }
        [TestMethod]
        public void Paginator_TotalRecords_ThrowsExceptionNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Paginator(-20, 30));
        }
        [TestMethod]
        public void Paginator_GetSkipData_SkipFirstTenRecords()
        {
            IPaginator paginator = new Paginator(60, 10);

            paginator.SetCurrentPage(2);

            Assert.AreEqual(paginator.Skip, 10);
        }
        [TestMethod]
        public void Paginator_GetSkipData_ThrowExceptionNegative()
        {
            IPaginator paginator = new Paginator(60, 10);

            Assert.ThrowsException<ArgumentException>(() => paginator.SetCurrentPage(-20));
        }
        [TestMethod]
        public void Paginator_GetSkipData_ThrowExceptionEqualZero()
        {
            IPaginator paginator = new Paginator(60, 10);

            Assert.ThrowsException<ArgumentException>(() => paginator.SetCurrentPage(0));
        }
    }
}
