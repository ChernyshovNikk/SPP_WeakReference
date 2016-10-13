using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_WeakDelegate
{
    class DelegateProves
    {
        int value;
        public int GetProveInt { get { return value; } }
        public void ProveInt(int a, int b)
        {
            value = a * b;
        }
    }
}
