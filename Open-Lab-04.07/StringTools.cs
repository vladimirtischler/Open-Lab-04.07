using System;
using System.Linq;

namespace Open_Lab_04._07
{
    public class StringTools
    {
 
        public string Reverse(string original)
        {
            string a = "";
            for (int b = original.Length - 1; b >= 0; b--)
            {
                a = a + original[b];
            }
            return a;
        }
    }
}
