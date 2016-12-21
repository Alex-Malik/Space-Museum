using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceMuseum.Tests.Controllers
{
    using Services;
    using SpaceMuseum.Controllers;
    using SpaceMuseum.Tests.Base;
    using SpaceMuseum.Services;
    using SpaceMuseum.Data.Models;
    using SpaceMuseum.Tests.Base.Factories;

    [TestClass]
    public class ExhibitsControllerTests : TestBase
    {
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            ExhibitsController controller = new ExhibitsController(Scope.Resolve<ExhibitsService>());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDetails()
        {
            // Arrange
            ExhibitsController controller = new ExhibitsController(Scope.Resolve<ExhibitsService>());
            Exhibit ex = DbFactory.CreateExhibit();

            // Act
            ViewResult result = controller.Details(ex.ExhibitID) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
