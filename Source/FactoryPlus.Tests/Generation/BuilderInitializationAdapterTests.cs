using FactoryPlus.Generators;
using FactoryPlus.Tests.TestSpecific;
using NUnit.Framework;
using Rhino.Mocks;

namespace FactoryPlus.Tests.Generation
{
    [TestFixture]
    public class BuilderInitializationAdapterTests
    {
        [Test] 
        public void Create_Should_Use_Builder_To_Create_Instance()
        {
            var expected = new SimpleClass();
            var builder = MockRepository.GenerateMock<IObjectBuilder<SimpleClass>>();
            builder.Expect(x => x.Build()).Return(expected);
            
            SimpleClass actual = new BuilderInitializationAdapter<SimpleClass>(builder).Create();

            builder.VerifyAllExpectations();
            Assert.AreSame(actual, expected);
        }
    }
}
