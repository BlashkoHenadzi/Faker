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
        class Too
        {
            public List<string> _testllist;
        }
        class Dict
        {
            public Dictionary<string, string> _testdict;
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
        [TestMethod]
        public void Create_FillList_testListFilled()
        {
            Faker _faker = new Faker();
            Too _testList = _faker.Create<Too>();
            Assert.IsTrue(_testList._testllist.Count>0);

        }
        [TestMethod]
        public void Create_FillDictionary_testdictFilled()
        {
            Faker _faker = new Faker();
            Dict _testdict = _faker.Create<Dict>();
            Assert.IsTrue(_testdict._testdict.Count > 0);
        }
    }
}
