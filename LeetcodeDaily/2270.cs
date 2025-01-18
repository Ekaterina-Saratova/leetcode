using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution2270
    {
        public int WaysToSplitArray(int[] nums)
        {
            var result = 0;
            var sumLeft = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                sumLeft += nums[i];
            }

            var sumRight = 0;
            for (var i = nums.Length-1; i > 0; i--)
            {
                sumRight += nums[i];
                sumLeft -= nums[i];
                if (sumLeft >= sumRight)
                    result++;
            }

            return result;
        }
    }

    [TestFixture]
    public class Test2270
    {
        [Test]
        [TestCase(new int[] { 10, 4, -8, 7 }, 2)]
        [TestCase(new int[] { 2, 3, 1, 0 }, 2)]
        public void Test(int[] nums, int expected)
        {
            var solution = new Solution2270();
            var actual = solution.WaysToSplitArray(nums);
            Assert.AreEqual(expected, actual);
        }
    }
}
