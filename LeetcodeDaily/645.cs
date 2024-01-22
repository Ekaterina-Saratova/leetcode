using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution645
    {
        public int[] FindErrorNums(int[] nums)
        {
            var n = nums.Length;
            var expected = new HashSet<int>();
            for (var i = 1; i <= n; i++)
            {
                expected.Add(i);
            }

            var actual = new HashSet<int>();
            var result = new int[2];

            foreach (var num in nums)
            {
                expected.Remove(num);
                if (!actual.Add(num))
                    result[0] = num;
            }

            result[1] = expected.First();
            return result;
        }
    }

    [TestFixture]
    public class Tests645
    {
        [Test]
        [TestCase(new int[] { 1, 2, 2,4 }, new int[] {2,3})]
        [TestCase(new int[] { 1, 1 }, new int[] {1,2})]
        [TestCase(new int[] { 2, 2 }, new int[] {2,1})]
        public void Test(int[] arr, int[] expected)
        {
            var result = new Solution645().FindErrorNums(arr);
            Assert.AreEqual(expected, result);
        }
    }
}