namespace FactoryPlus.Tests
{
    using System;
    using System.Collections.Generic;
    using FactoryPlus.Build;
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

        [Test]
        public void GetMany_Creates_Many_Instances_Of_The_Specified_Type()
        {
            int counter = 0;

            factory.Define(() =>
                {
                    counter++;
                    var template = new SimpleClass { Counter = counter };
                    return template;
                });

            const int howMany = 50;
            IList<SimpleClass> instances = factory.GetMany<SimpleClass>(howMany);
            
            Assert.IsNotNull(instances);
            Assert.AreEqual(howMany, instances.Count);

            for (int i = 1; i < instances.Count; i++)
            {
                Assert.AreNotEqual(instances[i].Counter, instances[i - 1].Counter);
            }
        }

        [Test]
        public void GetMany_By_Instance_Name_Creates_Many_Instances_Of_The_Specified_Type()
        {
            int counter = 0;
            const string name = "21fsdf";

            factory.Define(name, () =>
                {
                    counter++;
                    var template = new SimpleClass { Counter = counter };
                    return template;
                });

            const int howMany = 50;
            IList<SimpleClass> instances = factory.GetMany<SimpleClass>(name, howMany);

            Assert.IsNotNull(instances);
            Assert.AreEqual(howMany, instances.Count);

            for (int i = 1; i < instances.Count; i++)
            {
                Assert.AreNotEqual(instances[i].Counter, instances[i - 1].Counter);
            }
        }

        #endregion
    }
}
