namespace FactoryPlus.Tests
{
    using System;

    using NUnit.Framework;

    using Rhino.Mocks;

    [TestFixture]
    public class FactoryTests
    {
        #region Globals

        private IFactorySession mockFactorySession;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            mockFactorySession = MockRepository.GenerateMock<IFactorySession>();
            Factory.FactorySession = mockFactorySession;
        }

        #endregion

        #region Tests

        [Test]
        public void Get_Passes_Call_To_Factory_Session()
        {
            mockFactorySession.Expect(x => x.Get<int>()).Return(2);
            Factory.Get<int>();
            mockFactorySession.VerifyAllExpectations();
        }

        [Test]
        public void Define_Passes_Call_To_Factory_Session()
        {
            var constructWith = new Func<int>(() => 1);
            mockFactorySession.Expect(x => x.Define(constructWith));
            Factory.Define(constructWith);
            mockFactorySession.VerifyAllExpectations();
        }


        #endregion
    }
}
