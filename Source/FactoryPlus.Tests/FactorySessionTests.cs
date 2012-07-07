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
        public void Define_With_Instance_Name_Throws_If_Name_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => factory.Define<SimpleClass>(null, () => null));
        }

        [Test]
        public void Define_With_Instance_Name_Throws_If_Construction_Function_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => factory.Define<SimpleClass>("name", null));
        }

        [Test]
        public void Define_Throws_If_Construction_Function_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => factory.Define<SimpleClass>(null));
        }

        [Test]
        public void GetNamedInstance_With_Null_Name_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => factory.Get<SimpleClass>(null));
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
