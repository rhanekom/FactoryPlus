using System.Collections.Generic;
using FactoryPlus.Generators;

namespace FactoryPlus
{
    public class BuildExpression<T> : IBuildExpression<T>
    {
        #region Globals

        private readonly IObjectBuilder<T> builder;

        #endregion

        #region Construction

        public BuildExpression(IObjectBuilder<T> builder)
        {
            this.builder = builder;
        }

        #endregion

        #region IBuildExpression<T> Members

        public IBuildExpression<T> Patch(System.Action<T> action)
        {
            builder.AddModification(new CustomModificationStrategy<T>(action));
            return this;
        }

        public IEnumerable<T> BuildMany(int howMany)
        {
            var items = new List<T>(howMany);

            for (int i = 0; i < howMany; i++)
            {
                items.Add(builder.Build());
            }

            return items;
        }

        public T Build()
        {
            return builder.Build();
        }

        #endregion
    }
}
