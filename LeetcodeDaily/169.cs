using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution169
    {
        //Should use Boyer-Moore Voting Algorithm.
        public int MajorityElement(int[] nums)
        {
            double n = nums.Length / 2;
            var dict = new Dictionary<int, int>();
            var max = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (dict.TryAdd(nums[i], 1))
                {
                    if (dict.Count == 1)
                        max = nums[i];
                }
                else
                {
                    var newMax = ++dict[nums[i]];
                    if (dict[max] < newMax)
                        max = nums[i];
                }
            }

            return max;
        }
    }

    [TestFixture]
    public class Test169
    {
        [Test]
        [TestCase(new int[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
        [TestCase(new int[] { 3, 2, 3 }, 3)]
        [TestCase(new int[] { 6, 5, 5 }, 5)]
        public void Test(int[] arr, int expected)
        {
            var solution = new Solution169();
            Assert.AreEqual(expected, solution.MajorityElement(arr));
        }
    }
}
