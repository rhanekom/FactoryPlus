namespace FactoryPlus.Generators
{
    public interface IModificationStrategy<in T>
    {
        void Apply(T item);
    }
}
