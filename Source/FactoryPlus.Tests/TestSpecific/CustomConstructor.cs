namespace FactoryPlus.Tests.TestSpecific
{
    public class CustomConstructor
    {
        public CustomConstructor(string s)
        {
            Value = s;
        }

        public string Value { get; set; }
    }
}
