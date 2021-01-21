using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algoritmhs
{
    public static  class LetterCombinationsofaPhoneNumber
    {

        static List<string> result = new List<string>();


        public static List<String> Solution(String digits)
        {
            Dictionary<string, string> numbers = new Dictionary<string, string>();
            numbers.Add("2", "abc");
            numbers.Add("3", "def");
            numbers.Add("4", "ghi");
            numbers.Add("5", "jkl");
            numbers.Add("6", "mno");
            numbers.Add("7", "pqrs");
            numbers.Add("8", "tuv");
            numbers.Add("9", "wxyz");


            if (numbers.Count != 0)
                backtrack("", digits, numbers);
            return result;
        }

        public static void backtrack(string combination, string next_digits, Dictionary<string,string> phone)
        {
            // if there is no more digits to check
            if (next_digits.Length == 0)
            {
                // the combination is done
                result.Add(combination);
            }
            // if there are still digits to check
            else
            {
                // iterate over all letters which map 
                // the next available digit
                string digit = next_digits.Substring(0, 1);
                string letters = phone.GetValueOrDefault(digit);
                for (int i = 0; i < letters.Length; i++)
                {
                    string letter = phone.GetValueOrDefault(digit).Substring(i, i + 1);
                    // append the current letter to the combination
                    // and proceed to the next digits
                    backtrack(combination + letter, next_digits.Substring(1), phone);
                }
            }
        }
    }
}
