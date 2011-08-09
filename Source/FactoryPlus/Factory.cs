using System;

namespace FactoryPlus
{
    public static class Factory
    {
        #region Globals

        private static readonly IFactorySession staticSession = new FactorySession();

        #endregion
       
        public static void Setup<T>(Action<ISetupExpression> how)
        {
            staticSession.Setup<T>(how);
        }

        public static IBuildExpression<T> Default<T>()
        {
            return staticSession.Default<T>();
        }

        public static IBuildExpression<T> Template<T>(string fromTemplate)
        {
            return staticSession.Template<T>(fromTemplate);
        }
    }
}
