namespace FactoryPlus.Build
{
    using System;

    /// <summary>
    /// A builder that builds objects using a predefined delegate.
    /// </summary>
    /// <typeparam name="T">
    /// The type of object that this builder builds.
    /// </typeparam>
    public class DelegateBuilder<T> : BuilderBase<T>
    {
        #region Globals

        private readonly Func<T> constructWith;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateBuilder&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="constructWith">The delegate to construct the object with.</param>
        public DelegateBuilder(Func<T> constructWith)
        {
            if (constructWith == null)
            {
                throw new ArgumentNullException("constructWith");
            }

            this.constructWith = constructWith;
        } 

        #endregion

        #region BuilderBase<T> Members

        public override T Build()
        {
            return constructWith();
        }

        #endregion
    }
}
