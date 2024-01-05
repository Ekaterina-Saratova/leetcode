using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution300
    {
        public int LengthOfLIS(int[] nums)
        {
            var sub = new List<int> { nums[0] };

            for (var i = 1; i < nums.Length; i++)
            {
                if (sub.Last() < nums[i])
                {
                    sub.Add(nums[i]);
                    continue;
                }

                // Find index to replace
                var index = BinarySearch(sub, nums[i]);
                sub[index] = nums[i];
            }

            return sub.Count;
        }

        private int BinarySearch(List<int> list, int value)
        {
            var left = 0;
            var right = list.Count - 1;
            while (left <= right)
            {
                var middle = (left + right) / 2;

                if (value == list[middle])
                    return middle;
                if (value < list[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return left;
        }
    }

    [TestFixture]
    public class Tests300
    {
        [TestCase(new[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
        [TestCase(new[] { 0, 1, 0, 3, 2, 3 }, 4)]
        [TestCase(new[] { 7, 7, 7, 7, 7, 7, 7 }, 1)]
        [TestCase(new[] { 1, 7, 8, 4, 5, 6, -1, 9 }, 5)]
        public void TestOperations(int[] nums, int count)
        {
            var result = new Solution300().LengthOfLIS(nums);
            Assert.AreEqual(count, result);
        }

        // 1,7,8,4,5,6,-1,9
        // sub=[1]
        // sub=[1,7]
        // sub=[1,7,8]
        // We can't extend any existing sequence with 4.
        // So we need to create a new subsequence, but istead of a new sequence we create it
        // inside sub itself by replacing smallest element larger than 4.
        // sub=[1, 4 ,8]
        // Now, we can't extend with 5 either. We follow the same approach.
        // sub = [1,    4,    5]
        // We get 6 now and we can extend the sub list by picking it.
        // sub = [1,    4,    5,    6]
        // Cant extend with -1. So, Replace
        // sub = [-1,    4,    5,    6]
        // sub = [-1,    4,    5,    6,    9]
    }
}