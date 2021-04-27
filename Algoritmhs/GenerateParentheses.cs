using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algoritmhs
{
    public static class GenerateParentheses
    {
        public static List<String> Solution(int n)
        {
            List<string> ans = new List<string>();
            backtrack(ans, "", 0, 0, n);
            return ans;
        }
        public static void backtrack(List<String> ans, String cur, int open, int close, int max)
        {
            if (cur.Length == max * 2)
            {
                ans.Add(cur);
                return;
            }

            if (open < max)
                backtrack(ans, cur + "(", open + 1, close, max);
            if (close < open)
                backtrack(ans, cur + ")", open, close + 1, max);
        }
    }
}
