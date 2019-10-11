using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerClass;
namespace FakerTests
{
    [TestClass]
    public class FakerTest
    {
        class Foo
        {

        }
        [TestMethod]
        public void Create_SimpleObject_GenerateObj()
        {
            Faker _faker = new Faker();
            Foo _teststr = _faker.Create<Foo>();
            Assert.IsNotNull(_teststr);
        }
    }
}
