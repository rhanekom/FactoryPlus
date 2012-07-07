namespace FactoryPlus.Build
{
    using System;
    using System.Collections.Generic;

    internal class BuildDefinitionCollection
    {
        #region Globals

        private readonly Dictionary<Type, BuildDefinition> builders = new Dictionary<Type, BuildDefinition>();

        #endregion

        #region Public Members

        public void AddBuilder<T>(IBuilder<T> builder)
        {
            Set<T>(x => x.DefaultBuilder = builder);
        }

        public void AddBuilder<T>(string name, IBuilder<T> builder)
        {
            Set<T>(x => x.SetNamedBuilder(name, builder));
        }

        public BuildDefinition GetBuildDefinition<T>()
        {
            BuildDefinition definition;
            return builders.TryGetValue(typeof(T), out definition) ? definition : null;
        }

        public IBuilder GetBuilder<T>()
        {
            return Get<T>(x => x.DefaultBuilder);
        }

        public IBuilder GetBuilder<T>(string name)
        {
            return Get<T>(x => x.GetNamedBuilder(name));
        }

        #endregion

        #region Private Members

        private void Set<T>(Action<BuildDefinition> setter)
        {
            BuildDefinition definition = GetBuildDefinition<T>();

            if (definition == null)
            {
                definition = new BuildDefinition();
                builders.Add(typeof(T), definition);
            }

            setter(definition);
        }

        private IBuilder Get<T>(Func<BuildDefinition, IBuilder> getter)
        {
            BuildDefinition definition = GetBuildDefinition<T>();

            if (definition == null)
            {
                return null;
            }

            return getter(definition);
        }

        #endregion
    }
}
