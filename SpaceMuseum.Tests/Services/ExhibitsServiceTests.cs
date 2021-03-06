﻿using Autofac;
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

        [TestMethod]
        public void GetByEvent()
        {
            // Prepare test data
            Exhibit firstExhibit = _exhibits.First();
            Event evnt = DbFactory.CreateEvent((item) => item.Exhibits = new[] { firstExhibit });

            // Arrange
            ExhibitsService service = Scope.Resolve<ExhibitsService>();

            // Act
            IEnumerable<Exhibit> result = service.GetByEvent(evnt.EventID);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetByArticle()
        {
            // Prepare test data
            Exhibit firstExhibit = _exhibits.First();
            Article art = DbFactory.Create<Article>((item) => item.Exhibits = new[] { firstExhibit });

            // Arrange
            ExhibitsService service = Scope.Resolve<ExhibitsService>();

            // Act
            IEnumerable<Exhibit> result = service.GetByArticle(art.ArticleID);

            // Assert
            Assert.IsNotNull(result.Any());
        }
    }
}
