using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace FakerClass
{
    public class Faker : IFaker
    {
        public Faker()
        {
        }

        public T Create<T>()
        {
            object _object;
            _object = (T)GenerateObjectByConstructor<T>();
            return (T)_object;
        }

        private T GenerateObjectByConstructor<T>()
        {
          
        }
        private ConstructorInfo FindMatchingConstructor<T>()
        {
            ConstructorInfo[] _constructors = typeof(T).GetConstructors();
            ConstructorInfo _currentconstructor = null;
            foreach (ConstructorInfo constructor in _constructors)
            {
                if (constructor.GetParameters().Length > _currentconstructor.GetParameters().Length)
                    _currentconstructor = constructor;
            }
            return null;
        }
    }
}
