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
       
        public static decimal NextDecimal(Random rng)
        {
            byte scale = (byte)rng.Next(29);
            bool sign = rng.Next(2) == 1;
            return new decimal(NextInt32(rng),
                               NextInt32(rng),
                               NextInt32(rng),
                               sign,
                               scale);
        }
        public static int NextInt32(Random rng)
        {
            unchecked
            {
                int firstBits = rng.Next(0, 1 << 4) << 28;
                int lastBits = rng.Next(0, 1 << 28);
                return firstBits | lastBits;
            }
        }

        public override decimal Generate()
        {

            return NextDecimal(random);
        }
    }
}
