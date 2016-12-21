using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpaceMuseum.Tests
{
    using Services;
    using SpaceMuseum.Controllers;
    using SpaceMuseum.Tests.Base;
    using SpaceMuseum.Services;

    [TestClass]
    public class HomeControllerTests : TestBase
    {
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            HomeController controller = new HomeController(Scope.Resolve<EventsService>(), Scope.Resolve<ExhibitsService>());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}