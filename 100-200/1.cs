using NUnit.Framework;

namespace Grind75
{
    public class Solution1
    {
        // Brute force
        public int[] TwoSum(int[] nums, int target)
        {
            var i = 0;
            while (i < nums.Length)
            {
                var j = i+1;
                while (j < nums.Length)
                {
                    if (nums[j] + nums[i] == target)
                        return new[] { i, j };
                    j++;
                }

                i++;
            }

            return new int[2];
        }

        // HashMap
        public int[] TwoSumHash(int[] nums, int target)
        {
            var diffDict = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (diffDict.ContainsKey(nums[i]))
                    return new[] { i, diffDict[nums[i]] };
                var diff = target - nums[i];
                if (diff >= 0)
                {
                    diffDict.Add(diff, i);
                }
            }

            return new int[2];
        }
    }

    [TestFixture]
    public class Tests1
    {
        [TestCase(new [] { 2, 7, 11, 15 }, 9, new [] { 0, 1 })]
        [TestCase(new [] { 3, 2, 4 }, 6, new [] { 1,2 })]
        [TestCase(new [] { 3, 3 }, 6, new [] { 0,1 })]
        public void CheckBruteForce(int[] nums, int target, int[] expected)
        {
            var actual = new Solution1().TwoSum(nums, target);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 2, 7, 11, 15 }, 9, new[] { 1, 0 })]
        [TestCase(new[] { 3, 2, 4 }, 6, new[] { 2, 1 })]
        [TestCase(new[] { 3, 3 }, 6, new[] {1, 0 })]
        public void CheckHashMap(int[] nums, int target, int[] expected)
        {
            var actual = new Solution1().TwoSumHash(nums, target);
            Assert.AreEqual(expected, actual);
        }
    }
}

