namespace FactoryPlus.Build
{
    public abstract class BuilderBase<T> : IBuilder<T>
    {
        #region IBuilder<T> Members

        public abstract T Build();

        #endregion

        #region IBuilder Members

        object IBuilder.Build()
        {
            return this.Build();
        }

        #endregion
    }
}