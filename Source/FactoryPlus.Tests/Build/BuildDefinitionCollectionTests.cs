using System;

namespace FactoryPlus.Tests.Build
{
    using FactoryPlus.Build;
    using NUnit.Framework;
    using TestSpecific;

    [TestFixture]
    public class BuildDefinitionCollectionTests
    {
        [Test]
        public void AddDefault_Adds_A_Default_Build_Definition_For_The_Specified_Type()
        {
            var collection = new BuildDefinitionCollection();

            var expected = new DelegateBuilder<SimpleClass>(() => new SimpleClass());
            collection.AddBuilder(expected);
            BuildDefinition actual = collection.GetBuildDefinition<SimpleClass>();
            
            Assert.IsNotNull(actual);
            Assert.AreSame(expected, actual.DefaultBuilder);
        }

        [Test]
        public void AddDefault_Replaceds_Default_Builder_If_BuildDefinition_Already_Exists()
        {
            var collection = new BuildDefinitionCollection();

            var builder1 = new DelegateBuilder<SimpleClass>(() => new SimpleClass());
            collection.AddBuilder(builder1);

            BuildDefinition buildDefinition1 = collection.GetBuildDefinition<SimpleClass>();


            var builder2 = new DelegateBuilder<SimpleClass>(() => new SimpleClass());
            collection.AddBuilder(builder2);

            BuildDefinition buildDefinition2 = collection.GetBuildDefinition<SimpleClass>();

            Assert.AreSame(buildDefinition1, buildDefinition2);
            Assert.AreSame(buildDefinition2.DefaultBuilder, builder2);
        }

        [Test]
        public void GetBuildDefinition_Returns_Null_For_No_Build_Definition()
        {
            var collection = new BuildDefinitionCollection();
            BuildDefinition actual = collection.GetBuildDefinition<SimpleClass>();
            Assert.IsNull(actual);
        }

        [Test]
        public void AddNamedBuilder_Adds_Named_Builder_For_No_Build_Definition()
        {
            const string name = "ds223r";

            var collection = new BuildDefinitionCollection();

            var expected = new DelegateBuilder<SimpleClass>(() => new SimpleClass());
            collection.AddBuilder(name, expected);
            BuildDefinition actual = collection.GetBuildDefinition<SimpleClass>();

            Assert.IsNotNull(actual);
            Assert.AreSame(expected, actual.GetNamedBuilder(name));
        }

        [Test]
        public void GetBuilder_Returns_Null_For_No_Definition()
        {
            var collection = new BuildDefinitionCollection();
            IBuilder actual = collection.GetBuilder<SimpleClass>();
            Assert.IsNull(actual);
        }

        [Test]
        public void GetBuilder_Returns_Returns_Default_Instance()
        {
            var collection = new BuildDefinitionCollection();

            var expected = new DelegateBuilder<SimpleClass>(() => new SimpleClass());
            collection.AddBuilder(expected);
            
            IBuilder actual = collection.GetBuilder<SimpleClass>();
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void GetBuilder_With_Name_Returns_Null_For_No_Definition()
        {
            var collection = new BuildDefinitionCollection();
            IBuilder actual = collection.GetBuilder<SimpleClass>("name");
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetBuilder_With_Name_Returns_Returns_Named_Instance()
        {
            var collection = new BuildDefinitionCollection();

            const string name = "name";

            var expected = new DelegateBuilder<SimpleClass>(() => new SimpleClass());
            collection.AddBuilder(name, expected);

            IBuilder actual = collection.GetBuilder<SimpleClass>(name);
            Assert.AreSame(expected, actual);
        }
    }
}
