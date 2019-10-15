using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class DecimalValueGenerator : TypedValueGenerater<decimal>
    {
      
        public DecimalValueGenerator(Random random)
        {
            this.random = random;
        }

        public override decimal Generate()
        {
            return random.Next(Convert.ToInt32(decimal.MinValue), Convert.ToInt32((decimal.MaxValue)));
        }
    }
}
