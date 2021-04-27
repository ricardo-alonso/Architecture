using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algoritmhs
{
    public static class BracketMatcher
    {
        public static string Solution(string str)
        {
            var cnt = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    cnt++;
                }
                else if (str[i] == ')')
                {
                    cnt--;
                    if (cnt < 0) return "0";
                }
            }

            return "1";
        }

        public static string Solution2(string str)
        {
            if (str.Contains("(") || str.Contains(")"))
            {
                var left = new List<char>(str.ToCharArray()).Where(x => x == ')').Count();
                var right = new List<char>(str.ToCharArray()).Where(x => x == '(').Count();

                if (left != right)
                {
                    return "0";
                }
                else
                {
                    //si estan iguales verificamos el orden
                    List<char> letters = new List<char>(str.ToCharArray().Where(x=>!char.IsLetterOrDigit(x) && x!=' '));

                    //int counter = 0;
                    while (letters.Count>0)
                    {
                        if (letters[0] == '(')
                        {
                            var index = letters.IndexOf(')');
                            if (index > 0)//0 es la posicion actual
                            {
                                letters.RemoveAt(index);
                                letters.RemoveAt(0);                                
                            }
                        }
                        else
                        {
                            return "0";
                        }                        
                        //counter++;                        
                    }
                }
            }
            return "1";
        }
    }
}
