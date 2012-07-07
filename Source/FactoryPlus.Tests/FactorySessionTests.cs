using FactoryPlus.Build;

namespace FactoryPlus.Tests
{
    using System;
    using NUnit.Framework;
    using TestSpecific;

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
        public void Can_Create_Simple_Named_Object()
        {
            SimpleClass template = null;
            const string name = "23edf";

            factory.Define(name, () =>
                {
                    template = new SimpleClass();
                    return template;
                });

            var instance = factory.Get<SimpleClass>(name);
            Assert.IsNotNull(instance);
            Assert.AreSame(template, instance);
        }

        [Test]
        public void Undefined_Named_Instances_Throws_ArgumentException()
        {
            Assert.Throws<BuildException>(() => factory.Get<int>("asd"));
        }

        [Test]
        public void Undefined_Objects_Throws_ArgumentException()
        {
            Assert.Throws<BuildException>(() => factory.Get<int>());
        }

        #endregion
    }
}
