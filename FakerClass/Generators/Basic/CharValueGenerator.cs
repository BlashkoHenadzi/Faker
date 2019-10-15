using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class CharValueGenerator : TypedValueGenerater<char>
    {
        public CharValueGenerator(Random random)
        {
            this.random = random;
        }

        public override char Generate()
        {
            return (char)random.Next((char.MinValue), (char.MaxValue));
        }
    }
}
