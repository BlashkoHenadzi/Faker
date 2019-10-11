using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerClass;
namespace FakerTests
{
    [TestClass]
    class FakerTest
    {
        [TestMethod]
        public void Create_SimpleObject_GenerateObj()
        {
            Faker _faker = new Faker();
            string _teststr = _faker.Create<string>();
            Assert.IsNotNull(_teststr);
        }
    }
}
