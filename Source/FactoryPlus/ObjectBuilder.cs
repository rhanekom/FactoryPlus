using System.Collections.Generic;
using FactoryPlus.Generators;

namespace FactoryPlus
{
    public class ObjectBuilder<T> : IObjectBuilder<T>
    {
        #region Globals

        private readonly IInitalizationStrategy<T> creationStrategy;
        private readonly IList<IModificationStrategy<T>> modificationStrategies;

        #endregion

        #region Constructions

        public ObjectBuilder(IInitalizationStrategy<T> creationStrategy)
        {
            this.creationStrategy = creationStrategy;
            modificationStrategies = new List<IModificationStrategy<T>>();
        }

        #endregion

        #region IObjectFactory Members

        public T Build()
        {
            T item = creationStrategy.Create();

            foreach (var modificationStrategy in modificationStrategies)
            {
                modificationStrategy.Apply(item);
            }

            return item;
        }

        #endregion

        #region Public Members

        public void AddModification(IModificationStrategy<T> strategy)
        {
            modificationStrategies.Add(strategy);
        }

        #endregion
    }
}