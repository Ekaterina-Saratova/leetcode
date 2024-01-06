using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution1235
    {
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            var comparer = Comparer<int>.Create((x, y) => x == y ? 1 : x.CompareTo(y));
            var n = startTime.Length;
            var list = Enumerable.Range(0, n)
                .Select(i => (start: startTime[i], end: endTime[i], profit: profit[i]))
                .OrderBy(x => x.start).ToList();
            for (var i = 0; i < n; i++)
                startTime[i] = list[i].start;

            var dp = new int[n + 1];
            for (var k = n - 1; k >= 0; k--)
            {
                var i = Array.BinarySearch(startTime, k + 1, list.Count - k - 1, list[k].end, comparer);
                dp[k] = Math.Max(dp[k + 1], list[k].profit + dp[i < 0 ? ~i : i]);
            }
            return dp[0];
        }
    }

    [TestFixture]
    public class Tests1235
    {
        [TestCase(new[] { 1, 2, 3, 3 }, new[] { 3, 4, 5, 6 }, new[] { 50, 10, 40, 70 }, 120)]
        public void TestOperations(int[] startTime, int[] endTime, int[] profit, int expected)
        {
            var result = new Solution1235().JobScheduling(startTime, endTime, profit);
            Assert.AreEqual(expected, result);
        }
    }
}