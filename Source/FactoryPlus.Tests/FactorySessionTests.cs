namespace FactoryPlus.Tests
{
    using System;
    using TestSpecific;
    using NUnit.Framework;

    [TestFixture]
    public class FactorySessionTests
    {
        #region Globals

        private FactorySession factory;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            factory = new FactorySession();
        }

        #endregion

        #region Tests

        [Test]
        public void Can_Create_Simple_Object()
        {
            SimpleClass template = null;
            
            factory.Define(() =>
                { 
                    template = new SimpleClass();
                    return template;
                });

            var instance = factory.Get<SimpleClass>();
            Assert.IsNotNull(instance);
            Assert.AreSame(template, instance);
        }

        [Test]
        public void Undefined_Objects_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => factory.Get<int>());
        }

        #endregion
    }
}
