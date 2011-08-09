using System;
using System.Collections.Generic;

namespace FactoryPlus
{
    public interface IBuildExpression<out T>
    {
        IBuildExpression<T> Patch(Action<T> action);
        IEnumerable<T> BuildMany(int howMany);
        T Build();
    }
}
