using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution2225
    {
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            var counter = new Dictionary<int, int>();

            foreach (var m in matches)
            {
                if (!counter.ContainsKey(m[0]))
                    counter.Add(m[0], 100);

                if (counter.ContainsKey(m[1]))
                {
                    if(counter[m[1]] > 10)
                        counter[m[1]] = 0;
                    else
                    {
                        counter[m[1]] = -100;
                    }
                }

                if (!counter.ContainsKey(m[1]))
                    counter.Add(m[1], 0);
            }

            var result = new List<List<int>>() { new List<int>(), new List<int>() };
            foreach (var c in counter)
            {
                if (c.Value == 100)
                    result[0].Add(c.Key);
                if (c.Value == 0)
                    result[1].Add(c.Key);
            }

            result[0].Sort();
            result[1].Sort();

            return new List<IList<int>>() { result[0], result[1] };
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