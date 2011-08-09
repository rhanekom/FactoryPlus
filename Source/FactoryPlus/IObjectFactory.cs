namespace FactoryPlus
{
    public interface IObjectFactory<out T>
    {
        T Build();
    }
}
