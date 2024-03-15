using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution238
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            var extraSpace = new int[nums.Length];
            result[0] = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                result[i] = nums[i-1] * result[i-1];
            }

            extraSpace[nums.Length - 1] = 1;
            for (var i = nums.Length-2; i >= 0; i--)
            {
                extraSpace[i] = extraSpace[i+1] * nums[i + 1];
                result[i+1] *= extraSpace[i+1];
            }

            result[0] *= extraSpace[0];

            return result;
        }
    }

    [TestFixture]
    public class Tests238
    {
        [Test]
        [TestCase(new int[]{ 1, 2, 3, 4 }, new int[]{ 24, 12, 8, 6 })]
        [TestCase(new int[]{ -1, 1, 0, -3, 3 }, new int[]{ 0, 0, 9, 0, 0 })]
        public void Test(int[] n, int[] expected)
        {
            var result = new Solution238().ProductExceptSelf(n);
            Assert.AreEqual(expected, result);
        }
    }
}