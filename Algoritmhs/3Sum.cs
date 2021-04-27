using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algoritmhs
{
    //Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
    //Notice that the solution set must not contain duplicate triplets.
    public static class _3Sum
    {
        public static  IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            //if (nums.Length>1)
            //{
            //    List<int> list = new List<int>();
            //    result.Add(list);
            //}

            for (int i = 0; i < nums.Length - 1; i++)
            {
                // Find all pairs with sum equals to
                // "-arr[i]"
                HashSet<int> s = new HashSet<int>();
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var n1 = nums[i];
                    var n2 = nums[j];
                    int x = -(nums[i] + nums[j]);//hacemos la negacion
                    if (s.Contains(x))
                    {
                        Console.Write("{0} {1} {2}\n", x, nums[i], nums[j]);
                        //nums = true;
                    }
                    else
                    {
                        s.Add(nums[j]);
                    }
                }
            }


            return result;
        }


        public static IList<IList<int>> Result(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (nums.Length > 1)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    HashSet<int> s = new HashSet<int>();

                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        var n1 = nums[i];
                        var n2 = nums[j];
                        int x = -(nums[i] + nums[j]);
                        if (s.Contains(x))
                        {
                            List<int> tmp = new List<int>() { x, nums[i], nums[j] };
                            tmp.Sort();
                            if (!result.Any(t=>t.SequenceEqual(tmp)))//si la lista no ya contiene una lista con los mismos elementos
                            {
                                result.Add(tmp);
                            }

                        }
                        else
                        {
                            s.Add(nums[j]);
                        }
                    }
                }
            }
            return result;
        }
    }
}
