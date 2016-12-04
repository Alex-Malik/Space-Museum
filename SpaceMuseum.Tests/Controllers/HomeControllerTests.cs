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
    using SpaceMuseum.Tests.Base;

    [TestClass]
    public class HomeControllerTests : TestBase
    {
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}