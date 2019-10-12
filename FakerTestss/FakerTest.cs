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
            public string teststr;
            public string teststr2;
            public Foo(string ss)
          {
                this.teststr = ss;
            }
        }
        [TestMethod]
        public void Create_SimpleObject_GenerateObj()
        {
            Faker _faker = new Faker();
            Foo _teststr = _faker.Create<Foo>();
            Assert.IsNotNull(_teststr);
        }
        [TestMethod]
        public void Create_FillPropertyByConstructor_teststrFilled()
        {
            Faker _faker = new Faker();
            Foo _teststr = _faker.Create<Foo>();          
            Assert.IsNotNull(_teststr.teststr);
        }
    }
}
