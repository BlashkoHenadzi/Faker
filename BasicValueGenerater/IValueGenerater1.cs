using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicValueGenerater
{

    public interface IValueGenerater1
    {
        object Generate();
        Type TargetType { get; }
    }
    interface IValueGenerater1<out T> : IValueGenerater1
    {
        new T Generate();
    }
}
