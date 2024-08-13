using NUnit.Framework;

namespace Grind75
{
    public class Solution35
    {
        public int SearchInsert(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (true)
            {
                if (left == right)
                {
                    //equal
                    if (target == nums[left])
                        return left;
                    //to left
                    if (target < nums[left])
                        return left - 1 > 0 ? left - 1 : 0;
                    //to right
                    if (target > nums[left])
                        return left + 1;
                }

                if (left == right - 1)
                {
                    //in between
                    if (target > nums[left] && target < nums[right])
                        return left + 1;
                    //equal left
                    if (target == nums[left])
                        return left;
                    //equal right
                    if (target == nums[right])
                        return right;
                    //to left
                    if (target < nums[left])
                        return left - 1 > 0 ? left - 1 : 0;
                    //to right
                    if (target > nums[right])
                        return right + 1;
                }

                var center = left + (right - left + 1) / 2;
                if (nums[center] >= target)
                    right = center;
                else
                    left = center;
            }
        }
    }

    [TestFixture]
    public class Tests35
    {
        [TestCase(new [] { 1, 3, 5, 6 }, 5, 2)]
        [TestCase(new [] { 1, 3, 5, 6 }, 2, 1)]
        [TestCase(new [] { 1, 3, 5, 6 }, 7, 4)]
        [TestCase(new [] { 1, 3, 5, 6 }, 0, 0)]
        [TestCase(new [] { 2, 7, 8, 9, 10 }, 9, 3)]
        public void Check(int[] nums, int target, int expected)
        {
            var actual = new Solution35().SearchInsert(nums, target);
            Assert.AreEqual(expected, actual);
        }
    }
}

