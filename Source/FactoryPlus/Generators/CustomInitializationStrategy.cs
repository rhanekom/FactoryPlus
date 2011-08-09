using System;

namespace FactoryPlus.Generators
{
    public class CustomInitializationStrategy<T> : IInitalizationStrategy<T>
    {
        #region Globals

        private readonly Func<T> constructedBy;

        #endregion

        #region Construction

        public CustomInitializationStrategy(Func<T> constructedBy)
        {
            this.constructedBy = constructedBy;
        }

        #endregion

        #region IInitalizationStrategy<T> Members

        public T Create()
        {
            return constructedBy();
        }

        #endregion
    }
}
