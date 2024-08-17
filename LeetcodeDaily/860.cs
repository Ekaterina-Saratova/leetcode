using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution860
    {
        public bool LemonadeChange(int[] bills)
        {
            var change5 = 0;
            var change10 = 0;

            foreach (var b in bills)
            {
                if (b == 5)
                {
                    change5++;
                    continue;
                }

                if (b == 10)
                {
                    if (change5 < 1)
                        return false;

                    change5--;
                    change10++;
                    continue;
                }

                if (b == 20)
                {
                    if (change5 > 0 && change10 > 0)
                    {
                        change5--;
                        change10--;
                    }
                    else if (change5 > 2)
                        change5 -= 3;
                    else
                        return false;
                }
            }

            return true;
        }
    }

    [TestFixture]
    public class Test860
    {
        [Test]
        [TestCase(new int[] { 5, 5, 5, 10, 20 }, true)]
        [TestCase(new int[] { 5, 5, 10, 10, 20 }, false)]
        [TestCase(new int[] { 5, 5, 5, 5, 20, 20, 5, 5, 5, 5 }, false)]
        [TestCase(new int[] { 5, 5, 5, 10, 20 }, true)]
        public void Test(int[] arr, bool expected)
        {
            var solution = new Solution860();
            Assert.AreEqual(expected, solution.LemonadeChange(arr));
        }
    }
}
