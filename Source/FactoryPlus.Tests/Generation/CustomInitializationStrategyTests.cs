using System;
using FactoryPlus.Generators;
using FactoryPlus.Tests.TestSpecific;
using NUnit.Framework;

namespace FactoryPlus.Tests.Generation
{
    [TestFixture]
    public class CustomInitializationStrategyTests
    {
        [Test]
        public void Can_Create_Items_With_Custom_Initialization_Expressions()
        {
            const string testValue = "test";
            Func<CustomConstructor> expression = () => new CustomConstructor(testValue);

            CustomConstructor instance = new CustomInitializationStrategy<CustomConstructor>(expression).Create();
            Assert.AreEqual(instance.Value, testValue);
        }
    }
}
