using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class LongValueGenerator : TypedValueGenerater<long>
    {
        public LongValueGenerator(Random random)
        {
            this.random = random;
        }

        public override long Generate()
        {
            return random.Next(int.MinValue, int.MaxValue);
        }
    }
}
