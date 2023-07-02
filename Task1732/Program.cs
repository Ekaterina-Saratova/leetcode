using System.Collections.Generic;
using System;

namespace Task1732
{
    /// <summary>
    /// There is a biker going on a road trip. The road trip consists of n + 1 points at different altitudes.
    /// The biker starts his trip on point 0 with altitude equal 0.
    /// 
    /// You are given an integer array gain of length n where gain[i] is the net gain in altitude
    /// between points i​​​​​​ and i + 1 for all (0 &lt;= i &lt; n).
    /// Return the highest altitude of a point.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var task1732 = new Solution();
            var r = task1732.LargestAltitude(new[] { -5, 1, 5, 0, -7 });
            Console.WriteLine(r);
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int LargestAltitude(int[] gain)
        {
            var max = 0;
            var currentAlt = 0;
            foreach (var g in gain)
            {
                currentAlt += g;
                if (currentAlt > max)
                    max = currentAlt;
            }

            return max;
        }
    }
}