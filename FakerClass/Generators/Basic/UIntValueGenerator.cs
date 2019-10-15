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
            return (uint)random.Next( Convert.ToInt32(uint.MinValue), Convert.ToInt32(uint.MaxValue));
        }
    }
}
