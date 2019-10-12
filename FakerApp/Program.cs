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
        class Foo
        {
            //string ss;
            public Foo(string aa)
            {
                //this.ss = aa;
            }
        }
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Foo f = faker.Create<Foo>();
            Console.WriteLine(f == null);
            Faker faker2 = new Faker();
        }
    }
}
