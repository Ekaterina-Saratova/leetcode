using NUnit.Framework;

namespace LeetCodeDaily
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-common-value/description
    /// </summary>
    public class Solution2450
    {
        public int GetCommon(int[] nums1, int[] nums2)
        {
            var i = 0;
            var j = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                    return nums1[i];
                if (nums1[i] < nums2[j])
                    i++;
                else
                    j++;
            }
            return -1;
        }


        public int GetCommonHashSet(int[] nums1, int[] nums2)
        {
            var common = nums1.ToHashSet();
            foreach (var x in nums2)
            {
                if (common.Contains(x))
                    return x;
            }

            return -1;
        }
    }

    [TestFixture]
    public class Tests2450
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 6 }, new int[] { 2,4 }, 2)]
        [TestCase(new int[] { 1,1,2}, new int[] { 2,4 }, 2)]
        [TestCase(new int[] { 2,4}, new int[] { 1,2 }, 2)]
        [TestCase(new int[] { 6, 8, 13, 22, 24, 26, 34, 45, 46, 51, 56, 60, 61, 65, 73, 77, 87, 90, 90, 94 }, 
            new int[] { 2, 8, 16, 21, 21, 23, 27, 33, 44, 53, 57, 61, 66, 68, 73, 77, 86, 87, 88, 99 }, 
            8)]
        public void Test(int[] nums1, int[] nums2, int expected)
        {
            var result = new Solution2450().GetCommon(nums1, nums2);
            Assert.AreEqual(expected, result);
        }
    }
}