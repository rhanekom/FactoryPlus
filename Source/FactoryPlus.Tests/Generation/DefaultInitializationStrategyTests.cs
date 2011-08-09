using FactoryPlus.Generators;
using FactoryPlus.Tests.TestSpecific;
using NUnit.Framework;

namespace FactoryPlus.Tests.Generation
{
    [TestFixture]
    public class DefaultInitializationStrategyTests
    {
        [Test]
        public void Can_Create_Instances_Of_Simple_Classes()
        {
            SimpleClass instance = new DefaultInitializationStrategy<SimpleClass>().Create();
            Assert.IsNotNull(instance);
        }
    }
}
