using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceMuseum.Tests.Base
{
    [TestClass]
    public abstract class TestBase
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {

        }
    }
}
