using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution633
    {
        public bool JudgeSquareSum(int c)
        {
            long a = 0;
            long b = (long)Math.Ceiling(Math.Sqrt(c));
            var max = b;

            while (a <= max && b >= 0)
            {
                var c1 = (a * a + b * b);
                if (c1 == c)
                    return true;
                if (c1 < c)
                    a++;
                if (c1 > c)
                    b--;
            }

            return false;
        }
    }

    [TestFixture]
    public class Tests633
    {
        [TestCase(8, true)]
        public void Test(int c, bool expected)
        {
            var result = new Solution633().JudgeSquareSum(c);
            Assert.AreEqual(expected, result);
        }
    }
}