using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceMuseum.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace SpaceMuseum.Controllers.Tests
{
    using Services;
    using SpaceMuseum.Tests.Base;

    [TestClass]
    public class HomeControllerTests : TestBase
    {
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            // TODO: Add AutoFac resolver for tests assembly
            HomeController controller = new HomeController(new EventsService(), new ExhibitsService());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}