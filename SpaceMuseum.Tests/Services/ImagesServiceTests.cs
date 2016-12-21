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
    public class ImagesServiceTests : TestBase
    {
        private IEnumerable<Image> _images;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _images = new[]
            {
                DbFactory.Create<Image>(),
                DbFactory.Create<Image>(),
                DbFactory.Create<Image>()
            };
        }

        [TestMethod]
        public void TestGetById()
        {
            // Arrange
            ImagesService service = Scope.Resolve<ImagesService>();

            // Act
            Image result = service.Get(_images.First().ImageID);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            ImagesService service = Scope.Resolve<ImagesService>();

            // Act
            IEnumerable<Image> result = service.Get();

            // Assert
            Assert.IsTrue(_images.Except(result).Count() == 0);
        }

        [TestMethod]
        public void GetByExhibit()
        {
            // Prepare test data
            Image firstImage = _images.First();
            Exhibit ex = DbFactory.CreateExhibit((item) => item.Images = new[] { firstImage });

            // Arrange
            ImagesService service = Scope.Resolve<ImagesService>();

            // Act
            IEnumerable<Image> result = service.GetByExhibit(ex.ExhibitID);

            // Assert
            Assert.IsNotNull(result.Any());
        }
    }
}
