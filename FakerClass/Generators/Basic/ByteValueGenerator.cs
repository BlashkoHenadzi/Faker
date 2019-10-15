using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class ByteValueGenerator : TypedValueGenerater<byte>
    {

        public ByteValueGenerator(Random random)
        {
            this.random = random;
        }

        public override byte Generate()
        {

            return (byte)random.Next((byte.MinValue), (byte.MaxValue));
        }
    }
}

