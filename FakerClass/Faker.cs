using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using BasicValueGenerater;
using System.Runtime;
using System.Linq;
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
            object _generatedobj=null;
            ConstructorInfo _constructor = FindMatchingConstructor<T>();
            ParameterInfo[] _parametersinfo;

            if (_constructor != null)
            {
                _parametersinfo = _constructor.GetParameters();
                object[] _parametersvalue=null;
                if (_parametersinfo.Length>0)
                    _parametersvalue = GenerateValueByType<T>(_parametersinfo);
                _generatedobj = _constructor.Invoke(_parametersvalue);
            }
            else
                _generatedobj = Activator.CreateInstance(typeof(T));
            return (T)_generatedobj;
        }

        private object[] GenerateValueByType<T>(ParameterInfo[] parametersinfo)
        {
            List<object> _parametersvalue=new List<object>();
            foreach(ParameterInfo parameterInfo in parametersinfo)
            {

                var _generators = from v in Assembly.GetExecutingAssembly().GetTypes()
                                where typeof(IValueGenerater1).IsAssignableFrom(v)&&
                                     ( v.Name == parameterInfo.ParameterType.Name+"ValueGenerater") //   && t.GetMethod(_parametertype.ToString() + "ValueGenerater") != null
                                select Activator.CreateInstance(v)as IValueGenerater1;

                foreach (var _generator in _generators)
                {
                    _parametersvalue.Add(_generator.GenerateValue());
                }
            }
            return _parametersvalue.ToArray();
        }

        private ConstructorInfo FindMatchingConstructor<T>()
        {
            ConstructorInfo[] _constructors = typeof(T).GetConstructors();
            ConstructorInfo _currentconstructor = _constructors[0];
            foreach (ConstructorInfo constructor in _constructors)
            {
                if (constructor.GetParameters().Length > _currentconstructor.GetParameters().Length)
                    _currentconstructor = constructor;
            }
            return _currentconstructor;
        }
    }
}
