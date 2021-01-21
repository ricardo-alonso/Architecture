using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmhs
{
    public static class RomanToInt
    {
        public static int Solution(string s)
        {
            List<int> decimals = new List<int>() { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            List<string> romans = new List<string>() { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int last = Convert.ToInt32(decimals[romans.IndexOf(s[s.Length - 1].ToString())]);
            int result = last;

            //comenzamos con el penultimo
            for (int i = s.Length -2; i >= 0; i--)
            {                
                int index = decimals[romans.IndexOf(s[i].ToString())];
                if (index<last)
                {
                    result-=index;                
                }
                else
                {
                    result += index;
                }
                last = index;
            }

            return result;
        }
    }
}
