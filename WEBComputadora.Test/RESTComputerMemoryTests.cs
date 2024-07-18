using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEBComputadora.Services;

namespace WEBComputadora.Test
{
    [TestClass]
    public class RESTComputerMemoryTests
    {
        [TestMethod]
        public void RESTComputerMemory_GetComputers_FilterWithDescription()
        {
            var service = new RESTComputadoraMemoriaServicio();

            var computers = service.GetComputers("kings");

            Assert.IsTrue(computers.Count > 0);
        }
        [TestMethod]
        public void RESTComputerMemory_GetComputers_FilterWithCapacityHigherThan()
        {
            var service = new RESTComputadoraMemoriaServicio();

            var computers = service.GetComputers("", 0, 2);

            Assert.IsTrue(computers.Count > 0);
        }
    }
}
