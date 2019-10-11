using System;
using System.Collections.Generic;
using System.Text;

namespace FakerClass
{
    interface IFaker
    {
        T Create<T>();
    }
}
