using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class UShortValueGenerator : TypedValueGenerater<ushort>
    {    
        public UShortValueGenerator(Random random)
        {
            this.random = random;
        }

        public override ushort Generate()
        {
            return (ushort)random.Next(ushort.MinValue, ushort.MaxValue);
        }
    }
}
