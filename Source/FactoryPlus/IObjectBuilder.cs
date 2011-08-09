using FactoryPlus.Generators;

namespace FactoryPlus
{
    public interface IObjectBuilder<out T>
    {
        T Build();
        void AddModification(IModificationStrategy<T> strategy);
    }
}
