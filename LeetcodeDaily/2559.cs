using NUnit.Framework;

namespace LeetCodeDaily
{
    public class Solution2559
    {
        public int[] VowelStrings(string[] words, int[][] queries)
        {
            var ans = new int[queries.Length];
            var vows = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

            var prefixSum = new int[words.Length];
            var sum = 0;

            for (var i = 0; i < words.Length; i++)
            {
                if (vows.Contains(words[i][0]) && vows.Contains(words[i][words[i].Length - 1]))
                    sum++;
                prefixSum[i] = sum;
            }

            for (var i = 0; i < queries.Length; i++)
            {
                var currentQuery = queries[i];
                ans[i] = prefixSum[currentQuery[1]] - (currentQuery[0] == 0 ? 0 : prefixSum[currentQuery[0] - 1]);
            }

            return ans;
        }
    }

    [TestFixture]
    public class Test1422
    {
        [Test]
        public void Test()
        {
            var solution = new Solution2559();
            var words = new string[]{"aba", "bcb", "ece", "aa", "e"};
            int[][] queries = new int[3][];
            queries[0] = new int[2] {0, 2};
            queries[1] = new int[2] {1, 4};
            queries[2] = new int[2] {1, 1};

            var actual = solution.VowelStrings(words, queries);
            var expectedCount = new int[] { 2,3,0};
            Assert.AreEqual(expectedCount, actual);
        }
    }
}
