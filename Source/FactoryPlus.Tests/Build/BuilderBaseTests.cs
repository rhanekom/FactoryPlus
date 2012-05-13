namespace FactoryPlus.Tests.Build
{
    using FactoryPlus.Build;

    using NUnit.Framework;

    [TestFixture]
    public class BuilderBaseTests
    {
        #region Tests

        [Test]
        public void Build_Calls_And_Returns_Abstract_Build()
        {
            Assert.AreEqual(5, ((IBuilder) new TestBuilder()).Build());
        }

        #endregion

        #region Private Members

        public class TestBuilder : BuilderBase<int>
        {
            public override int Build()
            {
                return 5;
            }
        }

        #endregion
    }
}
