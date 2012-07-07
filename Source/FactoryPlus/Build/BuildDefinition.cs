namespace FactoryPlus.Build
{
    using System.Collections.Generic;

    internal class BuildDefinition
    {
        #region Globals

        private readonly IDictionary<string, IBuilder> namedBuilders  = new Dictionary<string, IBuilder>();

        #endregion

        #region Public Members

        public IBuilder DefaultBuilder { get; set; }

        public void SetNamedBuilder(string name, IBuilder builder)
        {
            namedBuilders[name] = builder;
        }

        public IBuilder GetNamedBuilder(string name)
        {
            IBuilder builder;
            return namedBuilders.TryGetValue(name, out builder) ? builder : null;
        }

        #endregion
    }
}
