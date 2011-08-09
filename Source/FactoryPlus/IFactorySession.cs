using System;

namespace FactoryPlus
{
    public interface IFactorySession
    {
        void Setup<T>(Action<ISetupExpression> how);
        IBuildExpression<T> Default<T>();
        IBuildExpression<T> Template<T>(string fromTemplate);
    }
}
