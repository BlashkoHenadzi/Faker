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
        class Bar
        {
            public string test3;
            public Foo _testFoo;
            public Bar(Foo sss,String _str)
            {
                _testFoo = sss;
                test3 = _str;
            }
        }
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
        [TestMethod]
        public void Create_FillPropertyOfOtherClass_propertyfield()
        {
            Faker _faker = new Faker();
            Bar _teststr = _faker.Create<Bar>();
            Assert.IsNotNull(_teststr._testFoo);
            
        }
    }
}
