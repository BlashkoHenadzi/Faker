using System;
using System.Collections.Generic;
using System.Text;
using BasicValueGenerater;
namespace FakerClass
{
    public class GeneratorsCollection
    {
        Dictionary<Type, IValueGenerater1> generaterList;

        public GeneratorsCollection()
        {
            generaterList = new Dictionary<Type, IValueGenerater1>();
        }
        public void AddGenerater(IValueGenerater1 generater)
        {
            generaterList.Add(generater.TargetType, generater);
        }
        public IValueGenerater1 GetGeneraterFromList(Type _generatertype)
        {
            IValueGenerater1 _generater = null;
            generaterList.TryGetValue(_generatertype, out _generater);
            return _generater;
        }
    }
}
