using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmhs
{
    public static class InsertionSort
    {
        public static int[] Result(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int counter = i;
                int current = arr[counter];
                int previous = arr[counter - 1];
                while (arr[counter] > arr[counter - 1] )
                {
                    int tmp = arr[counter];
                    arr[counter] = arr[counter - 1];
                    arr[counter - 1] = tmp;

                    if(counter >1)
                        counter--;
                }
            }

            return arr;
        }
    }
}
