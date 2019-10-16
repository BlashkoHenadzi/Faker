using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime;
using System.Linq;
using System.Globalization;
using FakerClass.Generators;
using BasicValueGenerater;
using FakerClass.Generators.Generics;
using FakerClass.Generators.Collections;
using FakerClass.Generators.Basic;
namespace FakerClass
{
    public class Faker : IFaker
    {
        GeneratorsCollection Genertors;
        HashSet<Type> _constructedtype;
        Random random;
       
        public Faker()
        {
            _constructedtype = new HashSet<Type>();           
            random = new Random();
            Genertors = new GeneratorsCollection();
            LoadGenerators(Assembly.GetExecutingAssembly());
            try
            {
                LoadGenerators(Assembly.LoadFile("C:\\Users\\USER\\source\\repos\\ClassLibrary3\\GeneratorsLib\\bin\\Debug\\GeneratorsLib.dll"));
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("DLL not found");
            }
            
            
        }

        private void LoadGenerators(Assembly assembly)
        {
            foreach (Type _type in assembly.GetTypes())
            {
                if (typeof(IValueGenerater1).IsAssignableFrom(_type))
                {
                    ElementGenerator elementGenerator = GenerateObject;

                    if (_type.GetInterfaces().Contains(typeof(IColletionGenerator)))
                        Genertors.AddGenerater((IValueGenerater1)_type.GetConstructors()[0].Invoke(new object[] { elementGenerator, random }));
                    else
                        Genertors.AddGenerater((IValueGenerater1)_type.GetConstructors()[0].Invoke(new object[] { random }));


                }

            }

        }

        public T Create<T>()
        {
            object _object;
            _object = (T)GenerateObject(typeof(T));
            return (T)_object;
        }
        
        private object GenerateObject(Type typeToCounstruct)
        {
            object _generatedobj = null;
            _generatedobj = GenerateValueByType(typeToCounstruct);
            if (_generatedobj != null)
                return _generatedobj;
            if (_constructedtype.Contains(typeToCounstruct))
                return null;
            else
                _constructedtype.Add(typeToCounstruct);  
                        
            ConstructorInfo _constructor = FindMatchingConstructor(typeToCounstruct);
            ParameterInfo[] _parametersinfo;
            if (_constructor != null)
            {
                _parametersinfo = _constructor.GetParameters();
                List<object> _parametersvalue = new List<object>();
                if (_parametersinfo.Length > 0)
                    foreach (ParameterInfo _parameter in _parametersinfo)
                        _parametersvalue.Add(GenerateValueByType(_parameter.ParameterType));
                _generatedobj = _constructor.Invoke(_parametersvalue.ToArray());
            }
            else
            {
                _generatedobj = Activator.CreateInstance(typeToCounstruct, true);

                GenerateFields(typeToCounstruct, ref _generatedobj);
                //GenerateProperties(typeToCounstruct, ref _generatedobj);
            }
            _constructedtype.Remove(typeToCounstruct);
            return _generatedobj;
        }

        private void GenerateProperties(Type typeToCounstruct, ref object generatedobj)
        {
            throw new NotImplementedException();
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
            {
                _parametersvalue = _parametergenerater.Generate();
                return _parametersvalue;
            }
            else
            if (_typeToGenerate.IsArray)
            {
                _parametergenerater = Genertors.GetGeneraterFromList(_typeToGenerate.BaseType);
                _parametersvalue = ((IColletionGenerator)_parametergenerater).Generate(_typeToGenerate);
                return _parametersvalue;
            }
            if (_typeToGenerate.IsEnum)
                return _typeToGenerate.GetEnumValues().GetValue(random.Next(0, _typeToGenerate.GetEnumValues().Length));
            if (_typeToGenerate.IsGenericType)
            {
                _parametergenerater = Genertors.GetGeneraterFromList(_typeToGenerate.GetGenericTypeDefinition());
                _parametersvalue = ((IColletionGenerator)_parametergenerater).Generate(_typeToGenerate);
            }
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
                if ((_currentconstructor == null)||(constructor.GetParameters().Length > _currentconstructor.GetParameters().Length))
                         _currentconstructor = constructor;
            }
            return _currentconstructor;
        }
    }
}
