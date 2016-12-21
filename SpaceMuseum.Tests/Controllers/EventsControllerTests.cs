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
    public class EventsControllerTests : TestBase
    {
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            EventsController controller = new EventsController(Scope.Resolve<EventsService>());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDetails()
        {
            // Arrange
            EventsController controller = new EventsController(Scope.Resolve<EventsService>());
            Event evnt = DbFactory.CreateEvent();

            // Act
            ViewResult result = controller.Details(evnt.EventID.ToString()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
