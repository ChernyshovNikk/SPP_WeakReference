using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeakReferences
{
    class WeakDelegate
    {
        WeakReference weakReference;
        MethodInfo methodInfo;
        CreateNewDelegate newDelegate;

        public WeakDelegate(Delegate currentDelegate)
        {
            weakReference = new WeakReference(currentDelegate.Target);
            methodInfo = currentDelegate.Method;
            newDelegate = new CreateNewDelegate();
        }

        public bool IsDelegateAlive { get { return weakReference.IsAlive; } }

        public Delegate Weak { get { return newDelegate.SetNewDelegate(methodInfo, weakReference); } }
        
        private class CreateNewDelegate
        {
            private MethodInfo delegate_MethodInfo;
            private WeakReference delegate_WeakReference;
           
            private Delegate DelegateInfo()
            {
            }

            public Delegate SetNewDelegate(MethodInfo methodInfo, WeakReference weakReference)
            {
                this.delegate_MethodInfo = methodInfo;
                this.delegate_WeakReference = weakReference;
                return DelegateInfo();
            }
        }       
    }
}