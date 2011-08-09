namespace FactoryPlus
{
    public interface IBuilderFactory
    {
        IObjectBuilder<T> GetBuilder<T>();
        IObjectBuilder<T> GetBuilder<T>(string template);
    }
}
