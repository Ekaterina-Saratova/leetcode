using NUnit.Framework;

namespace Grind75
{
    public class Solution1
    {
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
    }

    [TestFixture]
    public class Tests1
    {
        [TestCase(new [] { 2, 7, 11, 15 }, 9, new [] { 0, 1 })]
        [TestCase(new [] { 3, 2, 4 }, 6, new [] { 1,2 })]
        [TestCase(new [] { 3, 3 }, 6, new [] { 0,1 })]
        public void Check(int[] nums, int target, int[] expected)
        {
            var actual = new Solution1().TwoSum(nums, target);
            Assert.AreEqual(expected, actual);
        }
    }
}

