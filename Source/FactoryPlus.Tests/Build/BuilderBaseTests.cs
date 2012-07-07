namespace FactoryPlus.Tests.Build
{
    using System;
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

        [Test]
        public void BuildMany_Throws_For_Negative_Numbers()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TestBuilder().BuildMany(-1));
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