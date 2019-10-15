using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class FloatValueGenerator : TypedValueGenerater<float>
    {
        Random random;
        public FloatValueGenerator(Random random)
        {
            this.random = random;
        }

        public override float Generate()
        {
            return (float)random.NextDouble();
        }
    }
}
