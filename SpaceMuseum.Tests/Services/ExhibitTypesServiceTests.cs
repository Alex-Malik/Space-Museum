using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceMuseum.Tests.Services
{
    using Base;
    using Base.Factories;
    using Data.Models;
    using SpaceMuseum.Services;

    [TestClass]
    public class ExhibitTypesServiceTests : TestBase
    {
        private IEnumerable<ExhibitType> _exhibitTypes;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _exhibitTypes = new[]
            {
                DbFactory.Create<ExhibitType>(),
                DbFactory.Create<ExhibitType>(),
                DbFactory.Create<ExhibitType>()
            };
        }

        [TestMethod]
        public void TestGetById()
        {
            // Arrange
            ExhibitTypesService service = Scope.Resolve<ExhibitTypesService>();

            // Act
            ExhibitType result = service.Get(_exhibitTypes.First().ExhibitTypeID);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            ExhibitTypesService service = Scope.Resolve<ExhibitTypesService>();

            // Act
            IEnumerable<ExhibitType> result = service.Get();

            // Assert
            Assert.IsTrue(_exhibitTypes.Except(result).Count() == 0);
        }
    }
}
