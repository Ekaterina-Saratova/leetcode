using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution2485
    {
        public int PivotInteger(int n)
        {
            for (double i = 1; i <= n; i++)
            {
                var left = (i / 2) * (1 + i);
                var rigth = ((n - i + 1) / 2) * (i + n);
                if (left == rigth)
                    return (int)i;
            }
            return -1;
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