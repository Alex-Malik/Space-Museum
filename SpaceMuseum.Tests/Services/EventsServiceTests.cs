using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceMuseum.Tests
{
    using Base;
    using Base.Factories;
    using Data.Models;
    using SpaceMuseum.Services;

    [TestClass]
    public class EventsServiceTests : TestBase
    {
        private IEnumerable<Event> _events;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _events = DbFactory.CreateEvents(10);
        }

        [TestMethod]
        public void TestGetById()
        {
            // Arrange
            EventsService service = Scope.Resolve<EventsService>();

            // Act
            Event result = service.Get(_events.First().EventID);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            EventsService service = Scope.Resolve<EventsService>();

            // Act
            IEnumerable<Event> result = service.Get();

            // Assert
            Assert.IsTrue(_events.Except(result).Count() == 0);
        }
    }
}
