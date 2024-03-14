using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution930
    {
        public int NumSubarraysWithSum(int[] nums, int goal)
        {
            var last = 0;
            var sum = 0;
            var result = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum == goal)
                {
                    result++;
                }
                if (sum > goal || i == nums.Length-1)
                {
                    sum = 0;
                    i = last;
                    last++;
                }
            }
            return result;
        }
    }

    [TestFixture]
    public class Tests930
    {
        [Test]
        [TestCase(new int[]{ 1, 0, 1, 0, 1 },2, 4)]
        public void Test(int[] n, int goal, int expected)
        {
            var result = new Solution930().NumSubarraysWithSum(n, goal);
            Assert.AreEqual(expected, result);
        }
    }
}