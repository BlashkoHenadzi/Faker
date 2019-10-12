using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerClass;

namespace FakerApp
{
    class Program
    {
        class Bar
        {
            public string test3;
            public Foo _testFoo;            
        }
       

        class Foo
        {
            public string teststr;
            public string teststr2;
            public Coo _coo;

            public Foo(string teststr, string teststr2, Coo coo)
            {
                this.teststr = teststr;
                this.teststr2 = teststr2;
                _coo = coo;
            }
        }
        class Coo
        {
            public Coo(string ss1)
            {
                Ss1 = ss1;
            }
            public string Ss1 { get; }
        }
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Bar f = faker.Create<Bar>();
            Console.WriteLine(f == null);
            Faker faker2 = new Faker();
        }
    }
}
