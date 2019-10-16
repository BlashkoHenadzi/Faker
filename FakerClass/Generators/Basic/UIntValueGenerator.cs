using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class UIntValueGenerator : TypedValueGenerater<uint>
    {
        public UIntValueGenerator(Random random)
        {
            this.random = random;
        }

        public override uint Generate()
        {
            uint thirtyBits = (uint)random.Next(1 << 30);
            uint twoBits = (uint)random.Next(1 << 2);
            uint fullRange = (thirtyBits << 2) | twoBits;
            return fullRange;
        }
    }
}
