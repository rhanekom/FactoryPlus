using FactoryPlus.Generators;
using FactoryPlus.Tests.TestSpecific;
using NUnit.Framework;

namespace FactoryPlus.Tests.Generation
{
    [TestFixture]
    public class CustomModificationStrategyTests
    {
        [Test]
        public void Apply_Modifies_Item()
        {
            var instance = new SimpleClass();
            const string expected = "bla";
            var modificationStrategy = new CustomModificationStrategy<SimpleClass>(x => x.Value1 = expected);
            modificationStrategy.Apply(instance);
            Assert.AreSame(instance.Value1, expected);
        }
    }
}
