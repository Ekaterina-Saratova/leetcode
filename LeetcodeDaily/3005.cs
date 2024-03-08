using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution3005
    {
        public int MaxFrequencyElements(int[] nums)
        {
            var max = 0;
            var frequencies = new int[100];
            foreach (var n in nums)
            {
                frequencies[n-1] += 1;
                max = Math.Max(max, frequencies[n-1]);
            }

            var result = 0;
            for (var i = 0; i < 100; i++)
            {
                if (frequencies[i] == max)
                {
                    result += frequencies[i];
                }
            }
            return result;
        }
    }

    [TestFixture]
    public class Tests3005
    {
        [Test]
        [TestCase(new int[] { 1, 2, 2, 3, 1, 4 }, 4)]
        public void Test(int[] arr, int expected)
        {
            var result = new Solution3005().MaxFrequencyElements(arr);
            Assert.AreEqual(expected, result);
        }
    }
}