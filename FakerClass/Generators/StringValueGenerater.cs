using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators
{
   public class StringValueGenerater : TypedValueGenerater<string>
    {
        Random random;
        public StringValueGenerater()
        {
            random = new Random();
        }

         public override string Generate()
        {
            StringBuilder builder = new StringBuilder();
             
            
            char ch;
            int size = random.Next(1,40);
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
