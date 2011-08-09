using FactoryPlus.Generators;
using FactoryPlus.Tests.TestSpecific;
using NUnit.Framework;
using Rhino.Mocks;

namespace FactoryPlus.Tests
{
    [TestFixture]
    public class ObjectBuilderTests
    {
        #region Tests

        [Test]
        public void Build_Creates_Using_Initialization_Expression()
        {
            var expected = new SimpleClass();

            var initializationStrategy = MockRepository.GenerateMock<IInitalizationStrategy<SimpleClass>>();
            initializationStrategy.Expect(x => x.Create()).Return(expected);

            var factory = new ObjectBuilder<SimpleClass>(initializationStrategy);

            SimpleClass actual = factory.Build();

            initializationStrategy.VerifyAllExpectations();
            Assert.AreSame(actual, expected);
        }

        [Test]
        public void Build_Modifies_Using_Modification_Expressions()
        {
            var expected = new SimpleClass();

            var initializationStrategy = MockRepository.GenerateMock<IInitalizationStrategy<SimpleClass>>();
            initializationStrategy.Expect(x => x.Create()).Return(expected);

            var modificationStrategy1 = MockRepository.GenerateMock<IModificationStrategy<SimpleClass>>();
            modificationStrategy1.Expect(x => x.Apply(expected)).WhenCalled(delegate { expected.Value1 = "bla1"; });
           
            var modificationStrategy2 = MockRepository.GenerateMock<IModificationStrategy<SimpleClass>>();
            modificationStrategy2.Expect(x => x.Apply(expected)).WhenCalled(delegate { expected.Value2 = "bla2"; });

            var factory = new ObjectBuilder<SimpleClass>(initializationStrategy);
            factory.AddModification(modificationStrategy1);
            factory.AddModification(modificationStrategy2);

            SimpleClass actual = factory.Build();

            modificationStrategy1.VerifyAllExpectations();
            modificationStrategy2.VerifyAllExpectations();

            Assert.AreEqual(actual.Value1, "bla1");
            Assert.AreEqual(actual.Value2, "bla2");
        }

        #endregion
    }
}
