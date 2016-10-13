using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeakReferences;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UnitTest_WeakDelegate
{
    [TestClass]
    public class WeakDelegate_Tests
    {
        private event Action<int, int> eventIntTest;
        [TestMethod]
        public void IntWeak_Test()
        {
            DelegateProves delegateProves = new DelegateProves();
            WeakDelegate weakDelegate = new WeakDelegate((Action<int, int>)(delegateProves.ProveInt));
            eventIntTest += (Action<int, int>)weakDelegate;
            eventIntTest.Invoke(5, 8);
            Assert.AreEqual(delegateProves.GetProveInt, 40);
        }
    }
}