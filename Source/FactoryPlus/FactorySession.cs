using System;

namespace FactoryPlus
{
    public class FactorySession : IFactorySession
    {
        #region Globals

        private readonly TypeConfiguration configuration = new TypeConfiguration();
        private readonly IBuilderFactory builderFactory;

        #endregion

        #region Construction

        public FactorySession()
        {
            builderFactory = new BuilderFactory(configuration);
        }

        #endregion

        #region IFactorySession Members

        public void Setup<T>(Action<ISetupExpression> how)
        {
            throw new System.NotImplementedException();
        }

        public IBuildExpression<T> Default<T>()
        {
            return new BuildExpression<T>(builderFactory.GetBuilder<T>());
        }

        public IBuildExpression<T> Template<T>(string fromTemplate)
        {
            return new BuildExpression<T>(builderFactory.GetBuilder<T>(fromTemplate));
        }
        
        #endregion
    }
}