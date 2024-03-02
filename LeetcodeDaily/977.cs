using NUnit.Framework;
using System.Collections;

namespace LeetCodeDaily
{
    public class Solution977
    {
        public int[] SortedSquares(int[] nums)
        {
            var squares = nums.Select(n => n * n).ToArray();
            Array.Sort(squares);
            return squares;
        }
    }
}