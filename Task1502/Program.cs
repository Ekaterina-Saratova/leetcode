using System.Collections.Generic;
using System;

namespace Task1502
{
    //A sequence of numbers is called an arithmetic progression if the difference between any two consecutive elements is the same.
    //Given an array of numbers arr, return true if the array can be rearranged to form an arithmetic progression.
    //Otherwise, return false.
    public class Program
    {
        static void Main(string[] args)
        {
            var task1502 = new Solution();
            var r = task1502.CanMakeArithmeticProgression(new[] { 5, 1, 3, 7 });
            Console.WriteLine(r);
        }
    }

    public class Solution
    {
        //O(n)
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            var minValue = arr.Min();
            var maxValue = arr.Max();
            var n = arr.Length;

            if (maxValue - minValue == 0)
            {
                return true;
            }

            if ((maxValue - minValue) % (n - 1) != 0)
            {
                return false;
            }

            var diff = (maxValue - minValue) / (n - 1);
            var numberSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                if ((arr[i] - minValue) % diff != 0)
                {
                    return false;
                }
                numberSet.Add(arr[i]);
            }

            return numberSet.Count == n;
        }

        //O(n log n)
        public bool CanMakeArithmeticProgression1(int[] arr)
        {
            var n = arr.Length;
            BubbleSortIteration(arr, 0);
            BubbleSortIteration(arr, 1);
            var diff = arr[n - 1] - arr[n - 2];
            for (int i = 2; i < n; i++)
            {
                BubbleSortIteration(arr, i);
                if (arr[n - i] - arr[n - i - 1] != diff)
                    return false;
            }
            return true;
        }

        private void BubbleSortIteration(int[] arr, int count)
        {
            for (var i = 0; i < arr.Length - count - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    Swap(ref arr[i], ref arr[i + 1]);
                }
            }
        }

        public static void Swap(ref int first, ref int second)
        {
            (first, second) = (second, first);
        }
    }
}