using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_WeakDelegate
{
    class DelegateProves
    {
        private int intValue;
        public int GetProveInt { get { return intValue; } }
        public void ProveInt(int a, int b)
        {
            intValue = a * b;
        }


        private string text;
        public string GetProveString { get { return text; } }
        public void ProveString(string firstString, string secondString, string thirdString)
        {
            text = firstString + secondString + thirdString;
        }


        private double doubleValue;
        public double GetProveDouble { get { return doubleValue; } }
        public void ProveDouble(double value)
        {
            doubleValue = value;
        }


        private string mixValue;
        public string GetProveMix { get { return mixValue; } }
        public void ProveMix(int firstIntValue, string stringValue, int secondIntValue)
        {
            mixValue = firstIntValue.ToString() + stringValue + secondIntValue.ToString();
        }
    }
}
