using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEBComputadora.DAL.Contexts;
using WEBComputadora.DAL.Generators;

namespace WEBComputadora.Test
{
    [TestClass]
    public class WebDbContextTests
    {
        [TestMethod]
        public void WebDbContext_Initialize_WithTotalRecordsEqual60()
        {
            WebDbContext.SetRecordsToCreate(60);
            var context = new WebDbContext();

            Assert.AreEqual(60, context.Computadoras.Count);
        }
    }
}
