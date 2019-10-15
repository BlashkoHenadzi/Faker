using System;
using System.Collections.Generic;
using System.Text;

namespace FakerClass.Generators.Collections
{
    public delegate object ElementGenerator(Type _type);
    public interface IColletionGenerator
    {
       ElementGenerator ElementGenerator { get; }
        object Generate(Type _tvaluetype );
    }
}
