using FactoryPlus.Generators;

namespace FactoryPlus
{
    public class BuilderFactory : IBuilderFactory
    {
        #region Globals

        private readonly TypeConfiguration configuration;

        #endregion

        #region Construction

        public BuilderFactory(TypeConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region IBuilderFactory Members

        public IObjectBuilder<T> GetBuilder<T>()
        {
            IObjectBuilder<T> builder = configuration.GetDefaultFactory<T>();
            return builder ?? GetDefaultBuilder<T>();
        }

        public IObjectBuilder<T> GetBuilder<T>(string template)
        {
            IObjectBuilder<T> builder = configuration.GetTemplateFactory<T>(template);
            return builder ?? GetDefaultBuilder<T>();
        }

        #endregion

        #region Private Members

        private IObjectBuilder<T> GetDefaultBuilder<T>()
        {
            return new ObjectBuilder<T>(new DefaultInitializationStrategy<T>());
        }

        #endregion
    }
}