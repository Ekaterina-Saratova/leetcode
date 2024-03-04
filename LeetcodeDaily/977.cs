using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution977
    {
        public int[] SortedSquares(int[] nums)
        {
            var numsCount = nums.Length;
            var result = new int[numsCount];

            var startPointer = 0;
            var endPointer = numsCount - 1;
            var resultPointer = numsCount - 1;

            while (startPointer <= endPointer)
            {
                var start = nums[startPointer] * nums[startPointer];
                var end = nums[endPointer] * nums[endPointer];
                if (start >= end)
                {
                    result[resultPointer] = start;
                    startPointer++;
                }
                else
                {
                    result[resultPointer] = end;
                    endPointer--;
                }

                resultPointer--;
            }

            return result;
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