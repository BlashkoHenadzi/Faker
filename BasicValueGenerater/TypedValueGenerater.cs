﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicValueGenerater
{
    public abstract class TypedValueGenerater<T> : IValueGenerater1<T>
    {
        public Random random;
        public Type TargetType => ( typeof(T).IsGenericType? typeof(T).GetGenericTypeDefinition():typeof(T).IsEnum?typeof(T).BaseType:typeof(T));
        
        
        public abstract T Generate();

        object IValueGenerater1.Generate()

        {
           return Generate();
        }
    }
}
