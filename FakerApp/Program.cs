using FakerClass;
using System;
using System.Collections.Generic;
using System.Reflection;
namespace FakerApp
{
    class Program
    {
        class Bar
        {
            public string test3;
            public Foo _testFoo;
        }

        class Too
        {
            public List<string> _testllist;
            public Too(List<string> list)
            {
                this._testllist = list;
            }

        }
        public class Foo
        {
            public string teststr;
            public string teststr2;

            public Foo(string teststr, string teststr2)
            {
                this.teststr = teststr;
                this.teststr2 = teststr2;
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
        public enum Days { Monday, te };
        class Test
        {
            public Dict ss;
        }
        class Dict
        {
            public int[] dd;
            public Test dds;
            Days days;
            public Dict(int[] ss)
            {
                dd = ss;
            }
        }
        class Toos
        {
            public List<string> _testllist;
            public bool _testbool;
            public byte _byte;
            public char _char;
            public decimal _decimal;
            public double _double;
            public float _float;
            public int _int;
            public long _long;
            public sbyte _sbyte;
            public short _short;
            public string _string;
            public uint _uint;
            public ushort _ushort;
        }
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Bar f = faker.Create<Bar>();
            Console.WriteLine(f == null);
            Faker faker2 = new Faker();
            Too _too = faker2.Create<Too>();
            Faker _faker = new Faker();
            Dict _testdict = _faker.Create<Dict>();
            Assembly ass = Assembly.LoadFile("C:\\Users\\USER\\source\\repos\\ClassLibrary3\\GeneratorsLib\\bin\\Debug\\GeneratorsLib.dll");
            Type[] tt = ass.GetTypes();
            Toos ssss = _faker.Create<Toos>();



        }
    }
}