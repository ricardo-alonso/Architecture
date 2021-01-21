using System;
using System.Collections.Generic;
using System.Linq;

namespace Algoritmhs
{
    public static class LongestCommonPrefix
    {
        public static string Solution(string[] strs)
        {
            string result = "";
            if (strs.Length==1)
            {
                return strs[0];
            }
            if (strs.Length==0)
            {
                return result;
            }
            //Ordenamos las palabras por longitud
            List<string> words = strs.OrderBy(x=>x.Length).ToList<string>();

            //por cada letra de la palabra con menor longitud, validamos que sea la misma en toda la lista de palabras
            for (int i = 0; i < words[0].Length; i++)
            {
                if (words.All(s => s[i] == strs[0][i]))
                {
                    result += strs[0][i];
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
