using System;

namespace FactoryPlus.Generators
{
    public class CustomModificationStrategy<T> : IModificationStrategy<T>
    {
        #region Globals

        private readonly Action<T> modifiedBy;

        #endregion

        #region Construction

        public CustomModificationStrategy(Action<T> modifiedBy)
        {
            this.modifiedBy = modifiedBy;
        }

        #endregion

        #region IInitalizationStrategy<T> Members

        public void Apply(T item)
        {
            modifiedBy(item);
        }

        #endregion
    }
}
