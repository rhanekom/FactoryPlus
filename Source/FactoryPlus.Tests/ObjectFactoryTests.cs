using FactoryPlus.Generators;
using NUnit.Framework;
using Rhino.Mocks;

namespace FactoryPlus.Tests
{
    [TestFixture]
    public class ObjectFactoryTests
    {
        #region Tests

        [Test]
        public void Build_Creates_Using_Initialization_Expression()
        {
            var expected = new TestClass();

            var initializationStrategy = MockRepository.GenerateMock<IInitalizationStrategy<TestClass>>();
            initializationStrategy.Expect(x => x.Create()).Return(expected);

            var factory = new ObjectFactory<TestClass>(initializationStrategy);

            TestClass actual = factory.Build();

            initializationStrategy.VerifyAllExpectations();
            Assert.AreSame(actual, expected);
        }

        [Test]
        public void Build_Modifies_Using_Modification_Expressions()
        {
            var expected = new TestClass();

            var initializationStrategy = MockRepository.GenerateMock<IInitalizationStrategy<TestClass>>();
            initializationStrategy.Expect(x => x.Create()).Return(expected);

            var modificationStrategy1 = MockRepository.GenerateMock<IModificationStrategy<TestClass>>();
            modificationStrategy1.Expect(x => x.Apply(expected)).WhenCalled(delegate { expected.Value1 = "bla1"; });
           
            var modificationStrategy2 = MockRepository.GenerateMock<IModificationStrategy<TestClass>>();
            modificationStrategy2.Expect(x => x.Apply(expected)).WhenCalled(delegate { expected.Value2 = "bla2"; });

            var factory = new ObjectFactory<TestClass>(initializationStrategy);
            factory.AddModification(modificationStrategy1);
            factory.AddModification(modificationStrategy2);

            TestClass actual = factory.Build();

            modificationStrategy1.VerifyAllExpectations();
            modificationStrategy2.VerifyAllExpectations();

            Assert.AreEqual(actual.Value1, "bla1");
            Assert.AreEqual(actual.Value2, "bla2");
        }

        #endregion

        #region Private Members

        public class TestClass
        {
            public string Value1 { get; set; }
            public string Value2 { get; set; }
        }

        #endregion
    }
}
