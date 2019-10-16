using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicValueGenerater;
namespace GeneratorsLib
{
    class ArrayValueGenerator : TypedValueGenerater<Array>, IColletionGenerator
    {
        public ElementGenerator ElementGenerator { get; private set; }
        Random random;

        public ArrayValueGenerator(ElementGenerator ElementGenerator,Random random)
        {
            this.ElementGenerator = ElementGenerator;
            this.random = random;
        }
       
        public override Array Generate()
        {
            throw new NotImplementedException();
        }

        public object Generate(Type _tvaluetype)
        {
            int _arraysize = random.Next(30);
            Array _resultarray = Array.CreateInstance(_tvaluetype.GetElementType(), _arraysize);
            
            for (int i = 0; i < _arraysize; i++)
            {
                object _arrayelem = ElementGenerator.Invoke(_tvaluetype.GetElementType());
                _resultarray.SetValue(_arrayelem, i);
            }
            return _resultarray;
        }
    }
}
