using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
using System.Collections;
using FakerClass.Generators.Collections;
namespace FakerClass.Generators.Generics
{
    class ListGenerator : TypedValueGenerater<List<object>>, IColletionGenerator
    {

        Random _random;
        public ListElementGenerator listElementGenerator { get; private set; }
        public ListGenerator(ListElementGenerator listElementGenerator)
        {
            _random = new Random();
            this.listElementGenerator = listElementGenerator;
        }

        

        public override List<object> Generate()
        {
            List<object> _resultlist = new List<object>();
            int _listsize = _random.Next(1, 50);
            for (int i = 1; i <= _listsize; i++)
            {
                _resultlist.Add(listElementGenerator.Invoke(typeof(object)));
            }
            return _resultlist;
            
        }
        public object Generate( Type _tvaluetype)
        {
            Type _generatedtype = typeof(List<>).MakeGenericType(_tvaluetype.GenericTypeArguments[0]);
            IList _resultlist = (IList)Activator.CreateInstance(_generatedtype);
            int _listsize = _random.Next(1, 50);
            for (int i = 1; i <= _listsize; i++)                
            {
                _resultlist.Add(listElementGenerator.Invoke(_tvaluetype.GenericTypeArguments[0]));
            }           
            return _resultlist;
        }


    }
    

}
