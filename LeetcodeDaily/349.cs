using NUnit.Framework;

namespace LeetCodeDaily
{
    /// <summary>
    /// https://leetcode.com/problems/intersection-of-two-arrays
    /// </summary>
    public class Solution349
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var nums1HashSet = nums1.ToHashSet();
            var common = new HashSet<int>();
            foreach (var x in nums2)
            {
                if (nums1HashSet.Contains(x))
                    common.Add(x);
            }

            return common.ToArray();
        }
    }

    [TestFixture]
    public class Tests349
    {
        [Test]
        [TestCase(new int[] { 1, 2, 2,1 }, new int[] { 2,2 }, new int[]{2})]
        public void Test(int[] nums1, int[] nums2, int[] expected)
        {
            var result = new Solution349().Intersection(nums1, nums2);
            Assert.AreEqual(expected, result);
        }
    }
}