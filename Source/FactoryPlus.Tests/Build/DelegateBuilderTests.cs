namespace FactoryPlus.Tests.Build
{
    using System;

    using FactoryPlus.Build;

    using NUnit.Framework;

    [TestFixture]
    public class DelegateBuilderTests
    {
        [Test]
        public void Build_Builds_Object_From_Delegate_Supplied()
        {
            const int expected = 11;
            var builder = new DelegateBuilder<int>(() => expected);

            Assert.AreEqual(builder.Build(), expected);
        }

        [Test]
        public void Null_Delegate_Throws_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new DelegateBuilder<int>(null));
        }
    }
}
