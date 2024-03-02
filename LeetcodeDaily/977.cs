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

    [TestFixture]
    public class Tests977
    {
        [TestCase(new[] { -4, -1, 0, 3, 10 }, new[] { 0, 1, 9, 16, 100 })]
        [TestCase(new[] { -7, -3, 2, 3, 11 }, new[] { 4, 9, 9, 49, 121 })]
        public void Test(int[] nums, int[] expected)
        {
            var result = new Solution977().SortedSquares(nums);
            Assert.AreEqual(expected, result);
        }
    }
}