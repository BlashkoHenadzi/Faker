using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class ShortValueGeneartor : TypedValueGenerater<short>
    {
        public ShortValueGeneartor(Random random)
        {
            this.random = random;
        }

        public override short Generate()
        {
            return (short)random.Next(short.MinValue, short.MaxValue);
        }
    }
}
