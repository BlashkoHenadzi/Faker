using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class DoubleValueGenerator : TypedValueGenerater<double>
    {
        
        public DoubleValueGenerator(Random random)
        {
            this.random = random;
        }

        public override double Generate()
        {
            return random.NextDouble();
        }
    }
}
