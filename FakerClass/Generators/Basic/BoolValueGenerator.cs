using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators.Basic
{
    class BoolValueGenerator : TypedValueGenerater<bool>
    {
       
        public BoolValueGenerator(Random random)
        {
            this.random = random;
        }

        public override bool Generate()
        {
            //return (random.Next(0, 1) == 0 ? false : true) ;
            return true;
        }
    }
}
