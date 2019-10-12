using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass.Generators
{
    class StringValueGenerater : IValueGenerater1
    {
        public  object GenerateValue()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            int size = random.Next(1,30);
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
