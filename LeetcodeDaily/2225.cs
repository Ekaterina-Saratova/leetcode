using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution2225
    {
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            var winners = new HashSet<int>();
            var loosers = new Dictionary<int, int>();

            foreach (var m in matches)
            {
                winners.Add(m[0]);

                if (loosers.ContainsKey(m[1]))
                    loosers[m[1]]++;
                else
                {
                    loosers.Add(m[1], 1);
                }
            }

            var result = new List<IList<int>>() { new List<int>(), new List<int>() };
            foreach (var w in winners)
            {
                if (!loosers.ContainsKey(w))
                    result[0].Add(w);
                else if (loosers[w] == 1)
                    result[1].Add(w);
            }

            return result;
        }
    }

    [TestFixture]
    public class Tests2225
    {
        [Test]
        public void TestOperations()
        {
            var a1 = new int[][] { new [] {1, 3}, new[] { 2, 3}, new[] { 3, 6}, new[] { 5, 6}, new[] { 5, 7}, new[] { 4, 5}, new[] { 4, 8}, new[] { 4, 9}, new[] { 10, 4}, new[] { 10, 9 }};
            var expected = new List<List<int>>() { new List<int>() { 1, 2, 10 }, new List<int>() { 4, 5, 7, 8 } };
            var result = new Solution2225().FindWinners(a1);
            Assert.AreEqual(expected, result);
        }
    }
}