using System;
using System.Collections.Generic;
using System.Text;

namespace FakerClass.Generators.Collections
{
    public delegate object ListElementGenerator(Type _type);
    public interface IColletionGenerator
    {
        ListElementGenerator listElementGenerator { get; }
        object Generate(Type _tvaluetype );
    }
}
