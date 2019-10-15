using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class IntValueGenerator : TypedValueGenerater<int>
    {
       
        public IntValueGenerator(Random random)
        {
            this.random = random;
        }

        public override int Generate()
        {
            return random.Next(int.MinValue, int.MaxValue);
        }
    }
}
