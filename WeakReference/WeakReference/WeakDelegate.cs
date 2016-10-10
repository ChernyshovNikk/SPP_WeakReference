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
        MethodInfo method;
        CreateDelegate newDelegate;
       
        public WeakDelegate(Delegate currentDelegate)
        {
            weakReference = new WeakReference(currentDelegate.Target);
            method = currentDelegate.Method;
            newDelegate = new CreateDelegate();
        }

        private class CreateDelegate
        {

        }       
    }
}