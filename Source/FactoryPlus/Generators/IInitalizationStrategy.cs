namespace FactoryPlus.Generators
{
    public interface IInitalizationStrategy<out T>
    {
        T Create();
    }
}
