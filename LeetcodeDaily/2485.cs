using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution2485
    {
        public int PivotInteger(int n)
        {
            var sum = (n * (n + 1) / 2);
            var pivot = (int)Math.Sqrt(sum);
            return pivot * pivot == sum ? pivot : -1;
        }
    }

    [TestFixture]
    public class Tests2485
    {
        [Test]
        [TestCase(8, 6)]
        public void Test(int n, int expected)
        {
            var result = new Solution2485().PivotInteger(n);
            Assert.AreEqual(expected, result);
        }
    }
}