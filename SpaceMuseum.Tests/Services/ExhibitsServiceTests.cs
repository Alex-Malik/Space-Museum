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
    using Services;

    [TestClass]
    public class ExhibitsServiceTests : TestBase
    {
        private IEnumerable<Exhibit> _exhibits;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _exhibits = DbFactory.CreateExhibits(10);
        }

        [TestMethod]
        public void TestGetById()
        {
            // Arrange
            ExhibitsService service = Scope.Resolve<ExhibitsService>();

            // Act
            Exhibit result = service.Get(_exhibits.First().ExhibitID);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            ExhibitsService service = Scope.Resolve<ExhibitsService>();

            // Act
            IEnumerable<Exhibit> result = service.Get();

            // Assert
            Assert.IsTrue(_exhibits.Except(result).Count() == 0);
        }
    }
}
