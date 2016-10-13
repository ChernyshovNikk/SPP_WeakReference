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


        private event Action<string, string, string> eventStringTest;
        [TestMethod]
        public void StringWeak_Test()
        {
            DelegateProves delegateProves = new DelegateProves();
            WeakDelegate weakDelegate = new WeakDelegate((Action<string, string, string>)(delegateProves.ProveString));
            eventStringTest += (Action<string, string, string>)weakDelegate;
            eventStringTest.Invoke("a", "b", "c");
            Assert.AreEqual(delegateProves.GetProveString, "abc");
        }
    }
}