using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
using FakerClass.Generators.Collections;
using System.Collections;
namespace FakerClass.Generators.Collections
{
    class DictionaryGenearator : TypedValueGenerater<Dictionary<object, object>>,IColletionGenerator
    {
        public  ElementGenerator ElementGenerator { get; private set; }

        public DictionaryGenearator(ElementGenerator ElementGenerator, Random random)
        {
            this.random = random;
            this.ElementGenerator = ElementGenerator;
        }

        

        public override Dictionary<object, object> Generate()
        {
            Dictionary<object, object> _resultdict = new Dictionary<object, object>();
            int _dictionarysize = random.Next(1, 40);
            for (int i = 1; i < _dictionarysize; i++)
            {
                _resultdict.Add(ElementGenerator.Invoke(typeof(object)), ElementGenerator.Invoke(typeof(object)));
            }
            return _resultdict;
        }
        public object Generate(Type _ttype)
        {
            Type _tkeytype = _ttype.GetGenericArguments()[0];
            Type _tvaluetype = _ttype.GetGenericArguments()[1];
            IDictionary _resultdict = (IDictionary)Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(_tkeytype, _tvaluetype));
            int _dictionarysize = random.Next(1, 40);
            for (int i = 1; i < _dictionarysize; i++)
            {
                _resultdict.Add(ElementGenerator.Invoke(_tkeytype), ElementGenerator.Invoke(_tvaluetype));
            }
            return _resultdict;
        }
        
    }
}
