namespace FactoryPlus.Tests.Build
{
    using FactoryPlus.Build;
    using NUnit.Framework;
    using Rhino.Mocks;

    [TestFixture]
    public class BuildDefinitionTests
    {
        [Test]
        public void SetNamedBuilder_Sets_Builder_If_New()
        {
            var builder = MockRepository.GenerateMock<IBuilder>();

            const string name = "name";

            var buildDefinition = new BuildDefinition();
            buildDefinition.SetNamedBuilder(name, builder);

            Assert.AreSame(builder, buildDefinition.GetNamedBuilder(name));
        }

        [Test]
        public void SetNamedBuilder_Replaced_Builder_If_Not_New()
        {
            var builder1 = MockRepository.GenerateMock<IBuilder>();
            var builder2 = MockRepository.GenerateMock<IBuilder>();

            const string name = "name";

            var buildDefinition = new BuildDefinition();
            buildDefinition.SetNamedBuilder(name, builder1);
            buildDefinition.SetNamedBuilder(name, builder2);

            Assert.AreSame(builder2, buildDefinition.GetNamedBuilder(name));
        }

        [Test]
        public void GetNamedBuilder_Returns_Null_If_No_Builder_With_That_Name()
        {
            var buildDefinition = new BuildDefinition();
            Assert.IsNull(buildDefinition.GetNamedBuilder("name"));
        }
    }
}
