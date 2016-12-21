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
    public class ArticlesServiceTests : TestBase
    {
        private IEnumerable<Article> _articles;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _articles = new []
            {
                DbFactory.Create<Article>(),
                DbFactory.Create<Article>(),
                DbFactory.Create<Article>()
            };
        }

        [TestMethod]
        public void TestGetById()
        {
            // Arrange
            ArticlesService service = Scope.Resolve<ArticlesService>();

            // Act
            Article result = service.Get(_articles.First().ArticleID);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            ArticlesService service = Scope.Resolve<ArticlesService>();

            // Act
            IEnumerable<Article> result = service.Get();

            // Assert
            Assert.IsTrue(_articles.Except(result).Count() == 0);
        }

        [TestMethod]
        public void GetByExhibit()
        {
            // Prepare test data
            Article firstArticle = _articles.First();
            Exhibit ex = DbFactory.CreateExhibit((item) => item.Articles = new[] { firstArticle });

            // Arrange
            ArticlesService service = Scope.Resolve<ArticlesService>();

            // Act
            IEnumerable<Article> result = service.GetByExhibit(ex.ExhibitID);

            // Assert
            Assert.IsNotNull(result.Any());
        }
    }
}
