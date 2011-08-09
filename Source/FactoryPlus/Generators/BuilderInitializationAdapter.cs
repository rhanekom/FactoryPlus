namespace FactoryPlus.Generators
{
    public class BuilderInitializationAdapter<T> : IInitalizationStrategy<T>
    {
        #region Globals

        private readonly IObjectBuilder<T> builder;

        #endregion

        #region Construction

        public BuilderInitializationAdapter(IObjectBuilder<T> builder)
        {
            this.builder = builder;
        }

        #endregion

        #region IInitalizationStrategy<T> Members

        public T Create()
        {
            return builder.Build();
        }

        #endregion

    }
}
