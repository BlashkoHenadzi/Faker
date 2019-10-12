using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using System.Runtime;
using System.Linq;
using System.Globalization;
using System.Reflection;
using FakerClass.Generators;
using BasicValueGenerater;
namespace FakerClass
{
    public class Faker : IFaker
    {
        GeneratorsCollection Genertors;
        public Faker()
        {
             
            Genertors = new GeneratorsCollection();
            Genertors.AddGenerater(new StringValueGenerater());
        }

        public T Create<T>()
        {
            object _object;
            _object = (T)GenerateObjectByConstructor(typeof(T));
            return (T)_object;
        }

        private object GenerateObjectByConstructor(Type typeToCounstruct)
        {
            object _generatedobj=null;
            ConstructorInfo _constructor = FindMatchingConstructor(typeToCounstruct);
            ParameterInfo[] _parametersinfo;
            if (_constructor != null)
            {
                _parametersinfo = _constructor.GetParameters();
                List<object> _parametersvalue = new List<object>();
                if (_parametersinfo.Length>0)
                    foreach(ParameterInfo _parameter in _parametersinfo)
                        _parametersvalue.Add(GenerateValueByType(_parameter.ParameterType));
                _generatedobj = _constructor.Invoke(_parametersvalue.ToArray());
            }
            else
                _generatedobj = Activator.CreateInstance(typeToCounstruct,true);
            GenerateFields(typeToCounstruct, ref _generatedobj);
            return _generatedobj;
        }

        private void GenerateFields(Type _objtype, ref object _object)
        {
            var fields = _object.GetType().GetFields();
            foreach (FieldInfo _field in fields)
                _field.SetValue(_object, GenerateValueByType(_field.FieldType));
        }
        private object GenerateValueByType(Type _typeToGenerate)
        {
            object _parametersvalue = null;   
            IValueGenerater1 _parametergenerater = Genertors.GetGeneraterFromList(_typeToGenerate);
            if (_parametergenerater != null)
                _parametersvalue = _parametergenerater.Generate();
            else
                if (_typeToGenerate.IsClass)
                    _parametersvalue = GenerateObjectByConstructor(_typeToGenerate);
                else
                   _parametersvalue = null;
            return _parametersvalue;


        }


        private ConstructorInfo FindMatchingConstructor(Type _type)
        {
            ConstructorInfo[] _constructors = _type.GetConstructors();
            ConstructorInfo _currentconstructor = null;
            foreach (ConstructorInfo constructor in _constructors)
            {
                if (((_currentconstructor == null)
                   ||(constructor.GetParameters().Length > _currentconstructor.GetParameters().Length))&&(constructor.IsPublic))
                         _currentconstructor = constructor;
            }
            return _currentconstructor;
        }
    }
}
