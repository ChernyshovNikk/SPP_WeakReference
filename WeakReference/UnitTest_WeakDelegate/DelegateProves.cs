using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_WeakDelegate
{
    class DelegateProves
    {
        int intValue;
        public int GetProveInt { get { return intValue; } }
        public void ProveInt(int a, int b)
        {
            intValue = a * b;
        }


        string text;
        public string GetProveString { get { return text; } }
        public void ProveString(string firstString, string secondString, string thirdString)
        {
            text = firstString + secondString + thirdString;
        }


        double doubleValue;
        public double GetProveDouble { get { return doubleValue; } }
        public void ProveDouble(double value)
        {
            doubleValue = value;
        }
    }
}
