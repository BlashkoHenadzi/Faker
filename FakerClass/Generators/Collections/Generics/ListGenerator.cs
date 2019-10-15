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
        
        public ElementGenerator ElementGenerator { get; private set; }
        public ListGenerator(ElementGenerator ElementGenerator, Random random)
        {
            this.random = random;
            this.ElementGenerator = ElementGenerator;
        }

        

        public override List<object> Generate()
        {
            List<object> _resultlist = new List<object>();
            int _listsize = random.Next(1, 50);
            for (int i = 1; i <= _listsize; i++)
            {
                _resultlist.Add(ElementGenerator.Invoke(typeof(object)));
            }
            return _resultlist;
            
        }
        public object Generate( Type _tvaluetype)
        {
            Type _generatedtype = typeof(List<>).MakeGenericType(_tvaluetype.GenericTypeArguments[0]);
            IList _resultlist = (IList)Activator.CreateInstance(_generatedtype);
            int _listsize = random.Next(1, 50);
            for (int i = 1; i <= _listsize; i++)                
            {
                _resultlist.Add(ElementGenerator.Invoke(_tvaluetype.GenericTypeArguments[0]));
            }           
            return _resultlist;
        }


    }
    

}
