using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class SByteValueGenerator : TypedValueGenerater<sbyte>
    {
        public SByteValueGenerator(Random random)
        {
            this.random = random;
        }

        public override sbyte Generate()
        {
            return (sbyte)random.Next(sbyte.MinValue, sbyte.MaxValue);
        }
    }
}
