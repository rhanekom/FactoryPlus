using System.Collections.Generic;
using System.Linq;
using FactoryPlus.Tests.TestSpecific;
using NUnit.Framework;

namespace FactoryPlus.Tests
{
    [TestFixture]
    public class FactorySessionTests
    {
        #region Globals

        private FactorySession subject;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            subject = new FactorySession();
        }

        #endregion

        #region Tests

        [Test]
        public void Can_Build_Simple_Item()
        {
            SimpleClass instance = subject.Default<SimpleClass>().Build();
            Assert.IsNotNull(instance);
        }

        [Test]
        public void Can_Patch_Simple_Item()
        {
            const string patchValue = "patchValue";
            SimpleClass instance = subject.Default<SimpleClass>().Patch(x =>
                                                                            {
                                                                                x.Value1 = patchValue;
                                                                            }).Build();
            Assert.IsNotNull(instance);
            Assert.AreEqual(instance.Value1, patchValue);
        }

        [Test]
        public void Can_BuildMany_Simple_Items()
        {
            const int howMany = 50;
            
            IList<SimpleClass> instances = subject.Default<SimpleClass>().BuildMany(howMany).ToList();
            
            Assert.IsNotNull(instances);
            Assert.AreEqual(instances.Count, howMany);
        }

        #endregion

    }
}
