namespace FactoryPlus
{
    public interface IObjectBuilder<out T>
    {
        T Build();
    }
}
